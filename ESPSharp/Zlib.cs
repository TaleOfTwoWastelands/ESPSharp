using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using ICSharpCode.SharpZipLib.Zip.Compression;
using ICSharpCode.SharpZipLib.Zip.Compression.Streams;

namespace ESPSharp
{
    public static class Zlib
    {
        public static byte[] Decompress(Stream compressedStream, uint originalSize)
        {
            if (originalSize == 0)
                throw new ArgumentException("originalSize cannot be 0");

            using (var msDecompressed = DecompressStream(compressedStream, originalSize))
                return msDecompressed.ToArray();
        }

        public static MemoryStream DecompressStream(Stream compressedStream, uint originalSize)
        {
            if (originalSize == 0)
                throw new ArgumentException("originalSize cannot be 0");

            var msDecompressed = new MemoryStream((int)originalSize);
            using (var infStream = DecompressStreamInternal(compressedStream, originalSize))
                infStream.CopyTo(msDecompressed);

            msDecompressed.Seek(0, SeekOrigin.Begin);
            return msDecompressed;
        }

        private static Stream DecompressStreamInternal(Stream compressedStream, uint originalSize)
        {
            if (originalSize == 4)
                //Skip zlib descriptors and ignore header for this file
                compressedStream.Seek(2, SeekOrigin.Begin);

            return MakeZlibInflateStream(compressedStream, originalSize == 4);
        }

        private static Stream MakeZlibInflateStream(Stream inStream, bool skipHeader)
        {
            return new InflaterInputStream(inStream, new Inflater(skipHeader));
        }

        public static byte[] Compress(Stream decompressedStream, int level = 6)
        {
            using (MemoryStream msCompressed = new MemoryStream())
            {
                using (var defStream = MakeZlibDeflateStream(msCompressed, level))
                {
                    decompressedStream.CopyTo(defStream);
                }

                return msCompressed.ToArray();
            }
        }

        public static byte[] Compress(byte[] decompressedBytes, int level = 6)
        {
            byte[] outBytes;

            using (MemoryStream stream = new MemoryStream(decompressedBytes))
            {
                outBytes = Compress(stream).ToArray();
            }

            return outBytes;
        }

        public static Stream CompressStream(Stream msCompressed, int level = 6)
        {
            return MakeZlibDeflateStream(msCompressed, level);
        }

        private static Stream MakeZlibDeflateStream(Stream outStream, int level)
        {
            //you can substitute any zlib-compatible deflater here
            //gzip, zopfli, etc
            return new DeflaterOutputStream(outStream, new Deflater(level));
        }
    }
}