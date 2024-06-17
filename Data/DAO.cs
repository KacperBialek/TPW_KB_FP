using Bilard.Data;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Dynamic;
using System.Text.Json;

namespace Data
{
    internal class DAO : IDisposable
    {
        private Task logTask;
        private StreamWriter writer;
        private BlockingCollection<string> QueueToWrite;
        private string filePath = "../../../../Data/log.txt";
        public DAO()
        {
            QueueToWrite = new BlockingCollection<String>();
            writer = new StreamWriter(filePath, append: false);
            logTask = Task.Run(writeFile);
        }

        public void addToQueue(Ball ball)
        {
            if (ball == null)
            {
                return;
            }
            String ballString;
            String log;

            BallInfo ballLog = new BallInfo(ball.Position.X, ball.Position.Y, ball.Diameter, ball.Mass, ball.Speed.X, ball.Speed.Y, ball.ID);
            ballString = JsonSerializer.Serialize(ballLog);
            log = "{" + string.Format("\n\t\"BallInfo\": {0}\n", ballString) + "},";
            if (!QueueToWrite.IsAddingCompleted)
            {
                QueueToWrite.Add(log);
            }

        }

        private void writeFile()
        {
            try
            {
                foreach (string item in QueueToWrite.GetConsumingEnumerable())
                {
                    writer.WriteLine(item);
                }
            }
            finally
            {

                this.Dispose();
            }


        }

        public void Dispose()
        {
            writer.Flush();
            writer.Dispose();
            string text = File.ReadAllText(filePath);
            if (!string.IsNullOrEmpty(text))
            {
                text = text.Remove(text.Length - 3);
                File.WriteAllText(filePath, text + "\n]");
            }
            logTask.Wait();
            logTask.Dispose();
        }
    }

    internal class BallInfo
    {
        public float X { get; set; }
        public float Y { get; set; }
        public int Diameter { get; set; }
        public int Mass { get; set; }
        public float SpeedX { get; set; }
        public float SpeedY { get; set; }
        public int ID { get; set; }
        public string Time { get; set; }


        public BallInfo(float x, float y, int diameter, int mass, float spdX, float spdY, int id)
        {
            X = x;
            Y = y;
            Diameter = diameter;
            Mass = mass;
            SpeedX = spdX;
            SpeedY = spdY;
            ID = id;
            Time = DateTime.Now.ToString("G");
        }
    }
}