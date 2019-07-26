using System.IO;

namespace Transform_Linguistic_Data {
  class Program {
    const int  NameColumn  = 1,
               StartColumn = NameColumn+1;
    const char Delimiter   = ' ';

    static readonly char[] Delimiters = new char[] {Delimiter, '\t'};


    static ulong GetMask(string s) {
      // Convert string to a bit-mask with a single bit at the position of the number
      // This will throw an exception if string is not a number
      return 1UL << int.Parse(s);
    }

    static void ProcessLine(StreamWriter output, string line) {
      var columns = line.Split(Delimiters, System.StringSplitOptions.RemoveEmptyEntries);

      // Skip first column to eliminate unneeded number
      var   name  = columns[NameColumn];
      var   index = 1;
      ulong done  = 0;
      for (int i = StartColumn; i < columns.Length; ++i) {
        var mask = GetMask(columns[i]);

        // if not already processed
        if ((done & mask) == 0) {
          // Write out the old name with a dash and a zero-padded index number
          output.Write(name);
          output.Write("-{0:D2}", index++);
          output.Write(Delimiter);

          // Write out each column with a '1' if matches the current column, '0' otherwise
          for (int j = StartColumn; j < columns.Length; ++j) {
            output.Write(GetMask(columns[j]) == mask ? 1 : 0);
            output.Write(Delimiter);
          }

          // Mark this column as processed
          done |= mask;

          output.WriteLine();
        }
      }
    }

    static void ProcessHeader(StreamWriter output, string line) {
      // Copy out the header line with the first column removed
      var columns = line.Split(Delimiters, System.StringSplitOptions.RemoveEmptyEntries);
      for (int i = NameColumn; i < columns.Length; ++i) {
        output.Write(columns[i]);
        output.Write(Delimiter);
      }
      output.WriteLine();
    }

    static void ProcessFile(string name) {
      // Change this path if your data files are in a different folder
      var folder = "";

      using (var input  = new StreamReader(folder + name, true)) {
        using (var output = new StreamWriter(folder + "processed-" + name, false, System.Text.Encoding.ASCII)) {
          ProcessHeader(output, input.ReadLine());
          for (;;) {
            var line = input.ReadLine();
            if (line != null)
              ProcessLine(output, line);
            else
              break;
          }
        }
      }
    }

    static void Main(string[] args) {
      foreach (var arg in args)
        ProcessFile(arg);
    }
  }
}
