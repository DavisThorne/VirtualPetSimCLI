namespace VirtualPetSimCLI.main;

public static class ThreadedClass
{
    private static readonly object LockObject = new object();

    public static void RunThreadedLoops()
    {
        Thread agingLoop = new Thread(() =>
        {
            while (true)
            {
                Thread.Sleep(900000);
                lock (LockObject)
                {
                    SaveData.PetAge++;
                    Demo.petAge++;
                    PetParams.PetAgeLocal++;
                }
            }
        });
        agingLoop.Start();
        
        Thread hungerLoop = new Thread(() =>
        {
            while (true)
            {
                Thread.Sleep(60000);
                lock (LockObject)
                {
                    SaveData.PetHunger--;
                    Demo.petHunger--;
                    PetParams.PetHungerLocal--;
                }
            }
        });
        hungerLoop.Start();
    }
}


