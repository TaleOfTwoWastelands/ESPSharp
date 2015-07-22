using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TextTemplating;
using ESPSharp.Enums;
using ESPSharp.Enums.Flags;
using ESPSharp.Interfaces;
using ESPSharp.Subrecords;
using ESPSharp.SubrecordCollections;
using ESPSharp.DataTypes;

namespace ESPSharp.T4
{
    public abstract class ESPSharpCustomT4 : TextTransformation
    {
        public void SetIndent(int indentLevel, string indent = "\t")
        {
            ClearIndent();

            for (int i = 0; i < indentLevel; i++)
                PushIndent(indent);
        }

        public void WriteInterfaces(ClassTemplate template)
        {
            if (template.isComparable)
                Write(", IComparable<{0}>", template.ClassName);
            
            if (template.isEquatable)
                Write(", IEquatable<{0}>", template.ClassName);
            
            if (template.isReferenceable) 
                Write(", IReferenceContainer");
        }

        public void WritePropertyDeclaration(ClassField field, int indent = 2)
        {
            SetIndent(indent);

            if (field.isReadOnly)
                WriteLine("public {0} {1} {{ get; protected set; }}", field.TypeString, field.Name);
            else
                WriteLine("public {0} {1} {{ get; set; }}", field.TypeString, field.Name);

            ClearIndent();
        }

        public void WritePropertyInitializer(ClassField field, int indent = 3)
        {
            SetIndent(indent);

            string init;

            if (field.DefaultValue != null)
                init = field.DefaultValue;
            else if (field is RecordField && typeof(Subrecord).IsAssignableFrom(field.Type))
                init = String.Format("new {0}(\"{1}\")", field.TypeString, (field as RecordField).Tag);
            else if (field.Type == typeof(string))
                init = "\"\"";
            else if (field.Type != typeof(byte[]))
                init = String.Format("new {0}()", field.TypeString);
            else
                init = String.Format("new byte[{0}]", field.byteCount);

			WriteLine("{0} = {1};", field.Name, init);
             
            ClearIndent();
        }

        public void WriteParamsConstructorArgs(ClassTemplate template)
        {
            Write(string.Join(", ", template.Fields.Select<ClassField, string>(s => string.Format("{0} {1}", Utility.GetFriendlyName(s.Type), s.Name))));
        }

        public void WriteParamsConstructorAssignment(ClassField field, int indent = 3)
        {
            SetIndent(indent);

            WriteLine("this.{0} = {0};", field.Name);

            ClearIndent();
        }

        public void WriteCopyConstructorAssignment(ClassField field, int indent = 3)
        {
            SetIndent(indent);

            if (field.Type.GetInterface("IEnumerable`1") != null && field.Type.IsConstructedGenericType)
            {
                WriteLine("if (copyObject.{0} != null)", field.Name);
                PushIndent("\t");
                WriteLine("foreach(var temp in copyObject.{0})", field.Name);
                PushIndent("\t");
                WriteLine("{0}.Add({1});", field.Name, field.Type.GenericTypeArguments[0].GetCloneText("temp"));
                PopIndent();
                PopIndent();
            }
            else if (field.Type == typeof(object))
            {
                WriteLine("{0} = copyObject.{0};", field.Name);
            }
            else if (!field.Type.IsValueType)
            {
                WriteLine("if (copyObject.{0} != null)", field.Name);
                PushIndent("\t");
                WriteLine("{0} = {1};", field.Name, field.Type.GetCloneText(string.Format("copyObject.{0}", field.Name)));
            }
            else
                WriteLine("{0} = {1};", field.Name, field.Type.GetCloneText(string.Format("copyObject.{0}", field.Name)));

            ClearIndent();
        }

        public void WriteReadBinaryCommand(ClassField field, string readerName = "reader", int indent = 5)
        {
            SetIndent(indent);

            if (field.implementReadData)
                if (field.Type.GetInterface("IEnumerable`1") != null && field.Type.IsConstructedGenericType)
                {
                    if (field.hasListCount)
                    {
                        WriteLine("{0} {1}Count = {2}.Read{0}();", Utility.GetFriendlyName(field.listCountType), field.Name, readerName);
                        WriteLine("");
                        WriteLine("for (int i = 0; i < {0}Count; i++)", field.Name);
                    }
                    else if (field.listItemSize > 0)
                    {
                        WriteLine("for (int i = 0; i < size/{0}; i++)", field.listItemSize);
                    }
                    else
                        throw new Exception();

                    WriteLine("{");
                    PushIndent("\t");
                    if (field.Type.GenericTypeArguments[0].IsEnum)
                        WriteLine("{0}.Add({1}.ReadEnum<{2}>());", field.Name, readerName, field.Type.GenericTypeArguments[0].FriendlyName());
                    else if (field.Type.GenericTypeArguments[0] == typeof(byte[]))
                        WriteLine("{0}.Add({1}.ReadBytes({2}));", field.Name, readerName, field.byteCount);
                    else if (field.Type.GenericTypeArguments[0].GetInterface("IESPSerializable") != null)
                    {
                        WriteLine("var temp = new {0}();", field.Type.GenericTypeArguments[0].FriendlyName());
                        WriteLine("temp.ReadBinary({0});", readerName);
                        WriteLine("{0}.Add(temp);", field.Name);
                    }
                    else
                        WriteLine("{0}.Add({1}.Read{2}());", field.Name, readerName, field.Type.GenericTypeArguments[0].FriendlyName());
                    PopIndent();
                    WriteLine("}");
                }
                else if (field.Type == typeof(byte[]))
                    WriteLine("{0} = {1}.ReadBytes({2});", field.Name, readerName, field.byteCount);
                else if (field.Type.IsEnum)
                    WriteLine("{0} = {1}.ReadEnum<{2}>();", field.Name, readerName, field.TypeString);
                else if (field.Type.GetInterface("IESPSerializable") != null)
                    WriteLine("{0}.ReadBinary({1});", field.Name, readerName);
                else
                    WriteLine("{0} = {1}.Read{2}();", field.Name, readerName, field.TypeString);
            else
                WriteLine("Read{0}Binary({1});", field.Name, readerName);

            ClearIndent();
        }

        public void WriteWriteBinaryCommand(ClassField field, string writerName = "writer", int indent = 3)
        {
            SetIndent(indent);

            if (field.implementWriteData)
                if (field.Type.GetInterface("IEnumerable`1") != null && field.Type.IsConstructedGenericType)
                {
                    if (field.hasListCount)
                        WriteLine("{0}.Write(({1}){2}.Count);", writerName, Utility.GetFriendlyName(field.listCountType), field.Name);

                    if (field.isSorted && field.Type.GenericTypeArguments[0].GetInterface("IComparable`1") != null)
                        WriteLine("{0}.Sort();", field.Name);

                    WriteLine("foreach (var temp in {0})", field.Name);
                    WriteLine("{");
                    PushIndent("\t");

                    if (field.Type.GenericTypeArguments[0].IsEnum)
                        WriteLine("{0}.Write(({1})temp);", writerName, Utility.GetFriendlyName(Enum.GetUnderlyingType(field.Type.GenericTypeArguments[0])));
                    else if (field.Type.GenericTypeArguments[0].GetInterface("IESPSerializable") != null)
                        WriteLine("temp.WriteBinary({0});", writerName);
                    else
                        WriteLine("{0}.Write(temp);", writerName);

                    PopIndent();
                    WriteLine("}");
                }
                else if (field.Type.IsEnum)
                    WriteLine("{0}.Write(({1}){2});", writerName, Utility.GetFriendlyName(Enum.GetUnderlyingType(field.Type)), field.Name);
                else if (field.Type == typeof(byte[]))
                {
                    WriteLine("if ({0} == null)", field.Name);
                    WriteLine("\t{0}.Write(new byte[{1}]);",writerName, field.byteCount);
                    WriteLine("else");
                    WriteLine("{0}.Write({1});", writerName, field.Name);
                }
                else if (field.Type.GetInterface("IESPSerializable") != null)
                    WriteLine("{0}.WriteBinary({1});", field.Name, writerName);
                else
                    WriteLine("{0}.Write({1});", writerName, field.Name);
            else
                WriteLine("Write{0}Binary({1});", field.Name, writerName);

            ClearIndent();
        }

        public void WriteWriteXMLCommand(ClassField field, int indent = 3)
        {
            SetIndent(indent);

            if (field.implementWriteXML)
            {
                WriteLine("ele.TryPathTo(\"{0}\", true, out subEle);", field.XMLPath);
                if (field.Type.GetInterface("IEnumerable`1") != null && field.Type.IsConstructedGenericType)
                {
                    if (field.isSorted && field.Type.GenericTypeArguments[0].GetInterface("IComparable`1") != null)
                        WriteLine("{0}.Sort();", field.Name);

                    WriteLine("foreach (var temp in {0})", field.Name);
                    WriteLine("{");
                    PushIndent("\t");

                    if (field.Type.GenericTypeArguments[0] == typeof(Single))
                        WriteLine("subEle.Add(new XElement(\"{0}\", temp.ToString(\"G15\"));", field.XMLSubName);
                    else if (field.Type.GenericTypeArguments[0].GetInterface("IESPSerializable") != null)
                    {
                        WriteLine("XElement e = new XElement(\"{0}\");", field.XMLSubName);
                        WriteLine("temp.WriteXML(e, master);");
                        WriteLine("subEle.Add(e);");
                    }
                    else
                        WriteLine("subEle.Add(new XElement(\"{0}\", temp));", field.XMLSubName);

                    PopIndent();
                    WriteLine("}");
                }
                else if (field.Type == typeof(byte[]))
                    WriteLine("subEle.Value = {0}.ToHex();", field.Name);
                else if (field.Type == typeof(Single))
                    WriteLine("subEle.Value = {0}.ToString(\"G15\");", field.Name);
                else if (field.Type.GetInterface("IESPSerializable") != null)
                    WriteLine("{0}.WriteXML(subEle, master);", field.Name);
                else
                    WriteLine("subEle.Value = {0}.ToString();", field.Name);
            }
            else
                WriteLine("Write{0}XML(ele, master);", field.Name);

            ClearIndent();
        }

        public void WriteReadXMLCommand(ClassField field, int indent = 3)
        {
            SetIndent(indent);

            if (field.implementReadXML)
            {
                WriteLine("if (ele.TryPathTo(\"{0}\", false, out subEle))", field.XMLPath);
                PushIndent("\t");
                if (field.Type.GetInterface("IEnumerable`1") != null && field.Type.IsConstructedGenericType)
                {
                    WriteLine("foreach (XElement e in subEle.Elements())");
                    WriteLine("{");
                    PushIndent("\t");

                    if (field.Type.GenericTypeArguments[0].IsEnum)
                        WriteLine("{0}.Add(e.ToEnum<{1}>());", field.Name, field.Type.GenericTypeArguments[0].FriendlyName());
                    else if (field.Type.GenericTypeArguments[0] == typeof(string))
                        WriteLine("{0}.Add(e.Value);", field.Name);
                    else if (field.Type.GenericTypeArguments[0].GetInterface("IESPSerializable") != null)
                    {
                        WriteLine("var temp = new {0}();", field.Type.GenericTypeArguments[0].FriendlyName());
                        WriteLine("temp.ReadXML(e, master);");
                        WriteLine("{0}.Add(temp);", field.Name);
                    }
                    else
                        WriteLine("{0}.Add(e.To{1}());", field.Name, field.Type.GenericTypeArguments[0].FriendlyName());

                    PopIndent();
                    WriteLine("}");
                }
                else if (field.Type.IsEnum)
                    WriteLine("{0} = subEle.ToEnum<{1}>();", field.Name, field.TypeString);
                else if (field.Type == typeof(byte[]))
                    WriteLine("{0} = subEle.ToBytes();", field.Name, field.TypeString);
                else if (field.Type == typeof(string))
                    WriteLine("{0} = subEle.Value;", field.Name);
                else if (field.Type.GetInterface("IESPSerializable") != null)
                    WriteLine("{0}.ReadXML(subEle, master);", field.Name);
                else
                    WriteLine("{0} = subEle.To{1}();", field.Name, field.TypeString);
            }
            else
                WriteLine("Read{0}XML(ele, master);", field.Name);

            ClearIndent();
        }

        public void WriteCompareCommand(ClassField field, int indent = 4)
        {
            SetIndent(indent);

            if (field.Type == typeof(byte[]))
                WriteLine("result = {0}.GetHashCode().CompareTo(other.{0}.GetHashCode());", field.Name);
            else
                WriteLine("result = {0}.CompareTo(other.{0});", field.Name);

            ClearIndent();
        }
    }

    public class ClassTemplate
    {
        public string ClassName;
        public List<ClassField> Fields = new List<ClassField>();
        public bool isComparable = true;
        public bool isEquatable = true;
        public bool isReferenceable = false;

        public ClassField hashKey;
    }

    public class ClassField
    {
        public Type Type;
        public string Name;
        public string XMLPath;
        public string XMLSubName;
        public string DefaultValue;
        public int sortIndex = -1;

        public bool hasListCount = false;
        public bool isReadOnly = false;
        public bool implementReadData = true;
        public bool implementWriteData = true;
        public bool implementReadXML = true;
        public bool implementWriteXML = true;
        public bool isSorted = false;

        public uint byteCount = 0;
        public uint listItemSize = 0;

        public Type listCountType;

        public ClassField()
        {
        }

        public ClassField(Type Type, string Name, string XMLPath)
        {
            this.Type = Type;
            this.Name = Name;
            this.XMLPath = XMLPath;
        }

        public string TypeString
        {
            get
            {
                return Utility.GetFriendlyName(Type);
            }
        }

        public string EqualString
        {
            get
            {
                if (Type.GetInterface("IEnumerable`1") != null)
                    return String.Format("{0}.SequenceEqual(other.{0})", Name);
                else
                    return String.Format("{0} == other.{0}", Name);
            }
        }
    }

    public class RecordField : ClassField
    {
        public string Tag;
        public List<String> XMLSubNames;
        public bool isRequired = false;

        public RecordField(string Tag, Type Type, string Name, string XMLPath)
            :base(Type, Name, XMLPath)
        {
            this.Tag = Tag;
        }
    }
}