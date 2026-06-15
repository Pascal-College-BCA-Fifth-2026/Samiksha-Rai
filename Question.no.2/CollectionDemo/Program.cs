
﻿Collection collection = new();

Console.WriteLine("Animals");

string[] animals = collection.GetAnimals();

foreach (string animal in animals)
{
    Console.WriteLine(animal);
}

Console.WriteLine("\nSongs (Without Artist)");

List<Song> songs = collection.FetchSongs();

foreach (Song song in songs)
{
    Console.WriteLine($"{song.Name} - {song.Genre}");
}

Console.WriteLine("\nSongs (With Artist)");

List<Song> songsWithArtist =
    collection.FetchSongs(true);

foreach (Song song in songsWithArtist)
{
    Console.WriteLine(
        $"{song.Name} - {song.Genre} - {song.Artist}"
    );
}