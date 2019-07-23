using System.Text;

namespace LoggerApp
{
    /// <summary>
    ///Keeps all the messages appended to the file
    ///and sums the size of all their characters
    /// </summary>
    public class LogFile
    {
        private readonly StringBuilder sb;
        private int sum = 0;

        //Returns the sum of all characters, 
        //from all of the file's appended messages
        public int Size
        {
            get
            {
                var characters = sb.ToString().ToCharArray();
                foreach (var character in characters)
                {
                    if(char.IsLetter(character))
                    {
                        sum += character;
                    }
                }

                return sum;
            }
        }

        public LogFile()
        {
            sb = new StringBuilder();
        }

        //Adds to itsself the message appended to the file
        public void Write(string text)
        {
            sb.AppendLine(text);
        }

    }
}
