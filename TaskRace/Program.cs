namespace threadRace
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Read, Set Go...");
            int t1Location = 0;
            int t2Location = 0;
            int t3Location = 0;
            int t4Location = 0;
            int t5Location = 0;
            int t6Location = 0;

            //Creating Threads
            Task t1 = Task.Run(() =>
            {
                Thread.CurrentThread.Name = "Speedy Gonzales";
                for (int i = 0; i < 100; i++)
                {
                    if (t1Location < 100 && t2Location < 100
                    && t3Location < 100 && t4Location < 100
                    && t5Location < 100 && t6Location < 100)
                        MoveIt(ref t1Location);
                }

            });
            Task t2 = Task.Run(() =>
            {
                Thread.CurrentThread.Name = "Road Runner";
                for (int i = 0; i < 100; i++)
                {
                    if (t1Location < 100 && t2Location < 100
                    && t3Location < 100 && t4Location < 100
                    && t5Location < 100 && t6Location < 100)
                        MoveIt(ref t2Location);

                }
            });

            // New threads
            Task t3 = Task.Run(() =>
            {
                Thread.CurrentThread.Name = "Wile E. Coyote";
                for (int i = 0; i < 100; i++)
                {
                    if (t1Location < 100 && t2Location < 100
                    && t3Location < 100 && t4Location < 100
                    && t5Location < 100 && t6Location < 100)
                        MoveIt(ref t3Location);
                }
            });

            Task t4 = Task.Run(() =>
            {
                Thread.CurrentThread.Name = "Bugs Bunny";
                for (int i = 0; i < 100; i++)
                {
                    if (t1Location < 100 && t2Location < 100
                    && t3Location < 100 && t4Location < 100
                    && t5Location < 100 && t6Location < 100)
                        MoveIt(ref t4Location);
                }
            });

            Task t5 = Task.Run(() =>
            {
                Thread.CurrentThread.Name = "Daffy Duck";
                Thread.CurrentThread.Priority = ThreadPriority.AboveNormal;
                for (int i = 0; i < 100; i++)
                {
                    if (t1Location < 100 && t2Location < 100
                    && t3Location < 100 && t4Location < 100
                    && t5Location < 100 && t6Location < 100)
                        MoveIt(ref t5Location);
                }
            });

            Task t6 = Task.Run(() =>
            {
                Thread.CurrentThread.Name = "Elmber Fudd";
                for (int i = 0; i < 100; i++)
                {
                    if (t1Location < 100 && t2Location < 100
                    && t3Location < 100 && t4Location < 100
                    && t5Location < 100 && t6Location < 100)
                        MoveIt(ref t6Location);
                }
            });

            Task.WaitAny(t1);
            Task.WaitAny(t2);
            Task.WaitAny(t3);
            Task.WaitAny(t4);
            Task.WaitAny(t5);
            Task.WaitAny(t6);
            Console.WriteLine("Race has ended");
        }
        static void MoveIt(ref int location)
        {
            location++;
            Console.WriteLine($"{Thread.CurrentThread.Name} location={location}");
            if (location >= 100)
            {
                Console.WriteLine($"{Thread.CurrentThread.Name} is the winner");
                return;
            }
        }

    }
}