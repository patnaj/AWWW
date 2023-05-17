using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestMVC.Data;
using TestMVC.Models;

namespace TestMVC.Services
{
    public interface IStudentDbApi
    {
        ApplicationDbContext Db { get; }

        void AddMark(Mark ob);
        void AddStudent(Student ob);
        void Delete(object ob);
        List<Mark> GetMarksList(string? studentId, Func<Mark, bool>? w = null);
        Student? GetStudent(string? id, int? IndexId = null);
        List<Student> GetStudentList(Func<Student, bool>? w = null);
        void Commit();
        
    }

    public class StudentDbApi : IStudentDbApi
    {
        public TestMVC.Data.ApplicationDbContext Db { get; }
        public StudentDbApi(TestMVC.Data.ApplicationDbContext db)
        {
            this.Db = db;
        }

        public List<Student> GetStudentList(Func<Student, bool>? w = null)
        {
            return w == null ? Db.Users.ToList() : Db.Users.Where(w).ToList();
        }

        public Student? GetStudent(string? id, int? IndexId = null)
        {
            return id != null ? Db.Users.FirstOrDefault(i => i.Id == id) : Db.Users.FirstOrDefault(i => i.IndexID == IndexId);
        }

        public List<Mark> GetMarksList(string? studentId, Func<Mark, bool>? w = null)
        {
            var marks = Db.Marks.Where(m => (studentId == null || m.StudentId == studentId));
            return (w == null ? marks : marks.Where(w)).ToList();
        }

        public void AddStudent(Student ob)
        {
            Db.Users.Add(ob);
            Db.SaveChanges();
        }
        public void AddMark(Mark ob)
        {
            Db.Marks.Add(ob);
            Db.SaveChanges();
        }

        public void Delete(object ob)
        {
            if (ob is Student s)
                Db.Users.Remove(s);
            else if (ob is Mark m)
                Db.Marks.Remove(m);
            else
                return;
            Db.SaveChanges();
        }

        public void Commit()
        {
            Db.SaveChanges();
        }
    }
}