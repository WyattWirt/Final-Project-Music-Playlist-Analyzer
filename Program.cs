using System;
using System.IO;

namespace MusicPlaylistAnalyzer
{
    class Program
    {
        static readonly string[] FILE_HEADERS = { "Name", "Artist", "Album", "Genre", "Size", "Time", "Year", "Plays" };

        static void Main(string[] args)
        {
            if (args.Length == 2 && AreAllFilePaths(args))
            {
                try
                {
                    MusicalReader MusicalReader = new MusicalReader();
                    MusicPlaylist playlist = new MusicPlaylist(MusicalReader.ReadFile(args[0], FILE_HEADERS));
                    playlist.GenerateReport(args[1]);
                }
                catch (Exception error)
                {
                    Console.WriteLine(error.Message);
                }
            }
            else
            {
                Console.WriteLine("MusicPlaylistAnalyzer <Music_Playlist_File_Path> <Report_File_Path>");
            }
            Console.WriteLine("Successfully created Music Analysis Report: {0}", args[1]);
            Console.ReadLine();
        }

        static bool AreAllFilePaths(string[] paths)
        {
            foreach (string path in paths)
            {
                if (!Path.HasExtension(path))
                {
                    Console.WriteLine("\"{0}\" is not a correct file path", path);
                    return false;
                }
            }
            return true;
        }
    }
}
