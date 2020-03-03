using System.Collections.Generic;
using FileManager.Common.Layer;

namespace FileManager.DataAccess.Data
{
    public abstract class VuelingFile
    {
        public readonly string path;

        public abstract void CreateFile();
        public abstract Student Add(Student student);
        public abstract List<Student> Get();
        public abstract Student Update(Student student);
        public abstract bool Delete(Student student);
    }
}
