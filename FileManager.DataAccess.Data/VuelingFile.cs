using System.Collections.Generic;
using FileManager.Common.Layer;

namespace FileManager.DataAccess.Data
{
    public abstract class VuelingFile
    {
        public static readonly string path;
        public abstract Student Add(Student student);
        public abstract List<Student> GetAll();
        public abstract Student Update(Student student);
        public abstract bool Delete(Student student);
    }
}
