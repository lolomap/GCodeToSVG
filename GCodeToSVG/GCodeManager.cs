using gs;
using Sutro.PathWorks.Plugins.API;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCodeToSVG
{
	class GCodeManager
	{
		private readonly GenericGCodeParser parser = new();
		private GCodeFile gcParsed;
		private int pointer = 0;

		public int Pointer { set => pointer = value; }

		public void Open(string path)
		{
            using StreamReader reader = File.OpenText(path);
            gcParsed = parser.Parse(reader);
        }

		public GCodeLine NextLine()
		{
			return gcParsed[pointer++];
		}

		public GCodeLine GetLine(int index)
		{
			return gcParsed[index];
		}

		public IEnumerable<GCodeLine> GetLines()
		{
			return gcParsed.AllLines();
		}
	}
}
