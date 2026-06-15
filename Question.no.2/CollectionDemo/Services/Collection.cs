class Collection
{
    public string[] GetAnimals()
    {
        return new string[]
        {
            "Dog",
            "Cat",
            "Lion",
            "Hawk",
            "Rabbit"
        };
    }

    public List<Song> FetchSongs()
    {
        return new List<Song>()
        {
            new Song
            {
                Name = "Blinding Lights",
                Genre = "Pop",
                Artist = "The Weeknd"
            },
            new Song
            {
                Name = "Believer",
                Genre = "Rock",
                Artist = "Imagine Dragons"
            },
            new Song
            {
                Name = "Raataan Lambiyan",
                Genre = "Romantic",
                Artist = "Jubin Nautiyal"
            },
            new Song
            {
                Name = "Lose Yourself",
                Genre = "Hip Hop",
                Artist = "Eminem"
            }
        };
    }

public List<Song> FetchSongs(bool includeArtist)
{
    return new List<Song>()
    {
        new Song
        {
            Name = "Blinding Lights",
            Genre = "Pop",
            Artist = "The Weeknd"
        },
        new Song
        {
            Name = "Believer",
            Genre = "Rock",
            Artist = "Imagine Dragons"
        },
        new Song
        {
            Name = "Raataan Lambiyan",
            Genre = "Romantic",
            Artist = "Jubin Nautiyal"
        },
        new Song
        {
            Name = "Lose Yourself",
            Genre = "Hip Hop",
            Artist = "Eminem"
        }
    };
}
}