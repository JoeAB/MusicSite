using MusicData.Entities;
using MusicData.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
namespace MusicData.DataAccess
{
    class AlbumRepository
    {
            public bool SaveAlbum(IAlbum album)
            {
                try
                {
                    using (DataContext context = new DataContext())
                    {
                        context.Albums.Add((Album)album);
                        context.SaveChanges();
                    }
                }
                // we had an error and we're going to want to log it
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
                return true;
            }

            public IAlbum GetAlbum(int id)
            {
                IAlbum album;
                try
                {
                    using (DataContext context = new DataContext())
                    {
                        album = context.Albums.Single(x => x.albumID.Equals(id));
                    }
                }
                // we had an error and we're going to want to log it
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return null;
                }
                return album;
            }

            public List<IAlbum> GetAllAlbums()
            {
                List<IAlbum> albums;
                try
                {
                    using (DataContext context = new DataContext())
                    {
                        albums = context.Albums.ToList().ConvertAll(x => (IAlbum)x);
                    }
                }
                // we had an error and we're going to want to log it
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return null;
                }
                return albums;
            }

            public bool RemoveAlbum(IAlbum album)
            {
                try
                {
                    using (DataContext context = new DataContext())
                    {
                        context.Albums.Remove((Album)album);
                        context.SaveChanges();
                    }
                }
                // we had an error and we're going to want to log it
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
                return true;
            }

            public IAlbum GetByName(string name)
            {
                IAlbum album;
                try
                {
                    using (DataContext context = new DataContext())
                    {
                        album = context.Albums.Single(x => x.name.Equals(name));
                    }
                }
                // we had an error and we're going to want to log it
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return null;
                }
                return album;
            }

            public List<IAlbum> SearchByName(string name)
            {
                List<IAlbum> albums;
                try
                {
                    using (DataContext context = new DataContext())
                    {
                        albums = context.Albums.Where(x => x.name.Contains(name)).ToList().ConvertAll(x => (IAlbum)x);
                    }
                }
                // we had an error and we're going to want to log it
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return null;
                }
                return albums;
            }
    }
}
