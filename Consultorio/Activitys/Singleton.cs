using System;

public class Singleton
{
    private static Singleton instance;
    public int actualpaciente { get; set; }
    public int IdConsultaactual { get; set; }
    public Singleton() { }

    public static Singleton Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Singleton();
            }
            return instance;
        }
    }
}
