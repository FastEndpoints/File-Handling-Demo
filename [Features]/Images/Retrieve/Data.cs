﻿using GridFSAltDemo.Entities;

namespace Images.Retrieve
{
    public static class Data
    {
        public static Task ReadImageFromStorage(string imageID, Stream stream, CancellationToken ct)
        {
            return DB.File<Picture>(imageID).DownloadAsync(stream, 1, ct);
        }
    }
}