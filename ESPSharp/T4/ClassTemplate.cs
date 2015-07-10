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
                WriteLine("foreach(var temp in copyObject.{0})", field.Name);
                WriteLine("\t{0}.Add({1});", field.Name, field.Type.GenericTypeArguments[0].GetCloneText("temp"));
            }
            else
                WriteLine("{0} = {1};", field.Name, field.Type.GetCloneText(string.Format("copyObject.{0}", field.Name)));

            ClearIndent();
        }

        public void WriteReadBinaryCommand(ClassField field, int indent = 5)
        {
            SetIndent(indent);

            if (field.implementReadData)
                if (field.Type.IsEnum)
                    WriteLine("{0} = subReader.ReadEnum<{1}>();", field.Name, field.TypeString);
                else if (field.Type == typeof(byte[]))
                    WriteLine("{0} = subReader.ReadBytes({1});", field.Name, field.byteCount);
                else if (field.Type.GetInterface("IESPSerializable") != null)
                    WriteLine("{0}.ReadBinary(subReader);", field.Name);
                else
                    WriteLine("{0} = subReader.Read{1}();", field.Name, field.TypeString);
            else
                WriteLine("Read{0}Binary(subReader);", field.Name);

            ClearIndent();
        }

        public void WriteWriteBinaryCommand(ClassField field, int indent = 3)
        {
            SetIndent(indent);

            if (field.implementWriteData)
                if (field.Type.IsEnum)
                    WriteLine("writer.Write(({0}){1});", Utility.GetFriendlyName(Enum.GetUnderlyingType(field.Type)), field.Name);
                else if (field.Type == typeof(byte[]))
                {
                    WriteLine("if ({0} == null)", field.Name);
                    WriteLine("\twriter.Write(new byte[{0}]);", field.byteCount);
                    WriteLine("else");
                    WriteLine("writer.Write({0});", field.Name);
                }
                else if (field.Type.GetInterface("IESPSerializable") != null)
                    WriteLine("{0}.WriteBinary(writer);", field.Name);
                else
                    WriteLine("writer.Write({0});", field.Name);
            else
                WriteLine("Write{0}Binary(writer);", field.Name);

            ClearIndent();
        }

        public void WriteWriteXMLCommand(ClassField field, int indent = 3)
        {
            SetIndent(indent);

            if (field.implementWriteXML)
            {
                WriteLine("ele.TryPathTo(\"{0}\", true, out subEle);", field.XMLPath);
                if (field.Type == typeof(byte[]))
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
                if (field.Type.IsEnum)
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

        public void WriteCompareHashKeyCommand(ClassTemplate template, int indent = 3)
        {
            SetIndent(indent);

            if (template.hashKey.Type == typeof(byte[]))
                WriteLine("return {0}.GetHashCode().CompareTo(other.{0}.GetHashCode());", template.hashKey.Name);
            else
                WriteLine("return {0}.CompareTo(other.{0});", template.hashKey.Name);

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

        public bool isReadOnly = false;
        public bool implementReadData = true;
        public bool implementWriteData = true;
        public bool implementReadXML = true;
        public bool implementWriteXML = true;

        public uint byteCount = 0;

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
                if (Type == typeof(byte[]))
                    return String.Format("{0}.SequenceEqual(other.{0})", Name);
                else
                    return String.Format("{0} == other.{0}", Name);
            }
        }
    }
}