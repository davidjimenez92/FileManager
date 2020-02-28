using System.Collections.Generic;
using FileManager.Common.Layer;

namespace FileManager.DataAccess.Data
{
    public interface IFileFactory
    {
        Student Add(Student studen);

        List<Student> Get();

        Student Update(Student student);

        bool Delete(Student student);
    }
}
