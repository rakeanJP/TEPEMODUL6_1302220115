using System;
using System.Diagnostics.Contracts;

public class SayaTubeVideo
{
    private int id;
    private string title;
    private int playCount;

    public SayaTubeVideo(String title)
    {
        int max = 100;
        Contract.Requires(title.Length < max && title != null);
        try
        {
            checked
            {
                if ((title == null))
                {
                    throw new ArgumentException("Judul tidak bisa kosong");
                }
                else if (title.Length > max)
                {
                    throw new ArgumentException("Judul tidak bisa melebihi 100 karakter");
                }
                this.title = title;
                Random rand = new Random();
                int minRand = 100000;
                int maxRand = 999999;
                this.id = rand.Next(minRand, maxRand + 1);
                this.playCount = 0;
            }
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Error : {ex.Message}");
        }

        Contract.Ensures(this.title.Length < max && title != null);
    }

    public void IncreasePlayCount(int playCount)
    {
        if (this.title != null)
        {
            int max = 10000000;
            Contract.Requires(playCount < max);
            try
            {
                checked
                {
                    if (this.playCount + playCount > max)
                    {
                        throw new OverflowException("Jumlah Play Count melbihi maximum value");
                    }
                    this.playCount += playCount;
                }
            }
            catch (OverflowException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            Contract.Ensures(this.playCount < max);
        }
    }

    public void PrintVideoDetails()
    {
        if (this.title != null && this.playCount < 10000000)
        {
            Console.WriteLine($"ID Video : {id}");
            Console.WriteLine($"Title Video : {title}");
            Console.WriteLine($"Jumlah Tontonan : {playCount}");
        }
    }

    static void Main(string[] args)
    {
        string judul = "Tutorial Design By Contract - Rakean Mugen";
        SayaTubeVideo sayaTubeVideo = new SayaTubeVideo(judul);
        Random rand = new Random();
        int min = 1;
        int max = 10000000;
        sayaTubeVideo.IncreasePlayCount(rand.Next(min, max + 1));
        sayaTubeVideo.PrintVideoDetails();


    }
}