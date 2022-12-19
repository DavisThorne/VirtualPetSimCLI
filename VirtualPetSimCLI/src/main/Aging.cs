namespace VirtualPetSimCLI.main;

public static class Aging
{
    private static readonly object LockObject = new object();

    public static void Tick()
    {
        while (true)
        {
            lock (LockObject)
            {
                Demo.PetAge++;
            }
            Thread.Sleep(900000);
        }
    }
}