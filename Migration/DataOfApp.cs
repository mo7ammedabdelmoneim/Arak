using Arak.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arak
{
    public static class DataOfApp
    {
        public static void SeedData()
        {
            using (var context = new AppContext())
            {
                context.Database.EnsureCreated();

                bool levels = (context.Levels.FirstOrDefault() == null);
                bool Grades = (context.Grades.FirstOrDefault() == null);
                bool subjects = (context.Subjects.FirstOrDefault() == null);
                bool students = (context.Students.FirstOrDefault() == null);
                bool teachers = (context.Teachers.FirstOrDefault() == null);

                // Levels
                if (levels)
                {
                    context.Levels.AddRange(new Level { LevelID = 1, Name = "المرحلة الابتدائية" },
                                            new Level { LevelID = 2, Name = "المرحلة الاعدادية" },
                                            new Level { LevelID = 3, Name = "المرحلة الثانوية" });
                }

                // Grades
                if (Grades)
                {
                    context.Grades.AddRange(new Grade { GradeID = 1, Name = "الصف الاول الابتدائى", LevelID = 1, },
                                            new Grade { GradeID = 2, Name = "الصف الثانى الابتدائى", LevelID = 1 },
                                            new Grade { GradeID = 3, Name = "الصف الثالث الابتدائى", LevelID = 1 },
                                            new Grade { GradeID = 4, Name = "الصف الرابع الابتدائى", LevelID = 1 },
                                            new Grade { GradeID = 5, Name = "الصف الخامس الابتدائى", LevelID = 1 },
                                            new Grade { GradeID = 6, Name = "الصف السادس الابتدائى", LevelID = 1 },

                                            new Grade { GradeID = 11, Name = "الصف الاول الاعدادى", LevelID = 2 },
                                            new Grade { GradeID = 12, Name = "الصف الثانى الاعدادى", LevelID = 2 },
                                            new Grade { GradeID = 13, Name = "الصف الثالث الاعدادى", LevelID = 2 },

                                            new Grade { GradeID = 21, Name = "الصف الاول الثانوى", LevelID = 3 },
                                            new Grade { GradeID = 22, Name = "الصف الثانى الثانوى", LevelID = 3 },
                                            new Grade { GradeID = 23, Name = "الصف الثالث الثانوى", LevelID = 3 });
                }

                //Teachers
                if (teachers)
                {
                    context.Teachers.AddRange(new Teacher { Name = "محمد", Address = "الواسطى", Age = 20, Phone = "376467477", Faculty = "تربية" },
                                              new Teacher { Name = "احمد", Address = "أشمنت", Age = 20, Phone = "376467477", Faculty = "علوم" },
                                              new Teacher { Name = "على", Address = "بنى سويف", Age = 20, Phone = "376467477", Faculty = "صيدلة" },
                                              new Teacher { Name = "سيد", Address = "ببا", Age = 20, Phone = "376467477", Faculty = "هندسة" },
                                              new Teacher { Name = "اشرف", Address = "الواسطى", Age = 20, Phone = "376467477", Faculty = "تربية" },
                                              new Teacher { Name = "حسين", Address = "أشمنت", Age = 20, Phone = "376467477", Faculty = "علوم" },
                                              new Teacher { Name = "محسن", Address = "بنى سويف", Age = 20, Phone = "376467477", Faculty = "صيدلة" },
                                              new Teacher { Name = "خالد", Address = "ببا", Age = 20, Phone = "376467477", Faculty = "هندسة" });
                }

                //Subjects
                if (subjects)
                {
                    context.Subjects.AddRange(new Subject { Name = " عربى اولى ابتدائى", GradeId = 1, TeacherId = 1 },       // P-1
                                            new Subject { Name = "انجليزى اولى ابتدائى", GradeId = 1, TeacherId = 2 },
                                            new Subject { Name = "حساب اولى ابتدائى", GradeId = 1, TeacherId = 3 },
                                            new Subject { Name = "برايل اولى ابتدائى", GradeId = 1, TeacherId = 4 },

                                            new Subject { Name = "عربى تانية ابتدائى", GradeId = 2, TeacherId = 5 },      // P-2
                                            new Subject { Name = "انجليزى تانية ابتدائى", GradeId = 2, TeacherId = 6 },
                                            new Subject { Name = "حساب تانية ابتدائى", GradeId = 2, TeacherId = 7 },
                                            new Subject { Name = "برايل تانية ابتدائى", GradeId = 2, TeacherId = 3 },

                                            new Subject { Name = "عربى تالتة ابتدائى", GradeId = 3, TeacherId = 1 },      // P-3
                                            new Subject { Name = "انجليزى تالتة ابتدائى", GradeId = 3, TeacherId = 4 },
                                            new Subject { Name = "حساب تالتة ابتدائى", GradeId = 3, TeacherId = 4 },
                                            new Subject { Name = "برايل تالتة ابتدائى", GradeId = 3, TeacherId = 7 },

                                            new Subject { Name = "عربى رابعة ابتدائى", GradeId = 4, TeacherId = 8 },      // P-4
                                            new Subject { Name = "اجليزى رابعة ابتدائى", GradeId = 4, TeacherId = 2 },
                                            new Subject { Name = "حساب رابعة ابتدائى", GradeId = 4, TeacherId = 3 },
                                            new Subject { Name = "برايل رابعة ابتدائى", GradeId = 4, TeacherId = 6 },

                                            new Subject { Name = "عربى خامسة ابتدائى", GradeId = 5, TeacherId = 5 },      // P-5
                                            new Subject { Name = "انجليزى خامسة ابتدائى", GradeId = 5, TeacherId = 1 },
                                            new Subject { Name = "حساب خامسة ابتدائى", GradeId = 5, TeacherId = 4 },
                                            new Subject { Name = "برايل خامسة ابتدائى", GradeId = 5, TeacherId = 1 },

                                            new Subject { Name = "عربى الصف السادس الابتدائى", GradeId = 6, TeacherId = 3 },      // P-6
                                            new Subject { Name = "انجليزى الصف السادس الابتدائى", GradeId = 6, TeacherId = 1 },
                                            new Subject { Name = "حساب الصف السادس الابتدائى", GradeId = 6, TeacherId = 7 },
                                            new Subject { Name = "برايل الصف السادس الابتدائى", GradeId = 6, TeacherId = 8 },



                                             new Subject { Name = "عربى اولى اعدادى", GradeId = 11, TeacherId = 2 },
                                             new Subject { Name = "أنجليزى اولى اعدادى", GradeId = 11, TeacherId = 2 },   // M-1
                                             new Subject { Name = "درسات اولى اعدادى", GradeId = 11, TeacherId = 3 },
                                             new Subject { Name = "برايل اولى اعدادى", GradeId = 11, TeacherId = 4 },

                                             new Subject { Name = "عربى تانية اعدادى", GradeId = 12, TeacherId = 5 },      // m-2
                                             new Subject { Name = "أنجليزى تانية اعدادى", GradeId = 12, TeacherId = 6 },
                                             new Subject { Name = "درسات تانية اعدادى", GradeId = 12, TeacherId = 7 },
                                             new Subject { Name = "برايل تانية اعدادى", GradeId = 12, TeacherId = 3 },

                                             new Subject { Name = "عربى تالتة اعدادى", GradeId = 13, TeacherId = 1 },      // m-3
                                             new Subject { Name = "أنجليزى تالتة اعدادى", GradeId = 13, TeacherId = 4 },
                                             new Subject { Name = "درسات تالتة اعدادى", GradeId = 13, TeacherId = 4 },
                                             new Subject { Name = "برايل تالتة اعدادى", GradeId = 13, TeacherId = 7 },




                                             new Subject { Name = "عربى اولى ثانوى", GradeId = 21, TeacherId = 2 },
                                             new Subject { Name = "أنجليزى اولى ثانوى", GradeId = 21, TeacherId = 2 },   // S-1
                                             new Subject { Name = "درسات اولى ثانوى", GradeId = 21, TeacherId = 3 },
                                             new Subject { Name = "برايل اولى ثانوى", GradeId = 21, TeacherId = 4 },

                                             new Subject { Name = "عربى تانية ثانوى", GradeId = 22, TeacherId = 5 },      // S-2
                                             new Subject { Name = "أنجليزى تانية ثانوى", GradeId = 22, TeacherId = 6 },
                                             new Subject { Name = "درسات تانية ثانوى", GradeId = 22, TeacherId = 7 },
                                             new Subject { Name = "برايل تانية ثانوى", GradeId = 22, TeacherId = 3 },

                                             new Subject { Name = "عربى تالتة ثانوى", GradeId = 23, TeacherId = 1 },      // S-3
                                             new Subject { Name = "أنجليزى تالتة ثانوى", GradeId = 23, TeacherId = 4 },
                                             new Subject { Name = "درسات تالتة ثانوى", GradeId = 23, TeacherId = 4 },
                                             new Subject { Name = "برايل تالتة ثانوى", GradeId = 23, TeacherId = 7 });
                }

                //students
                if (students)
                {
                    context.Students.AddRange(new Student { Name = "محمد", Address = "الواسطى", Age = 20, Phone = "376467477", GradeID = 1, ParentName = "على", ParentPhone = "376467477" },
                                              new Student { Name = "احمد", Address = "أشمنت", Age = 20, Phone = "376467477", GradeID = 2, ParentName = "حسين", ParentPhone = "376467477" },
                                              new Student { Name = "على", Address = "بنى سويف", Age = 20, Phone = "376467477", GradeID = 6, ParentName = "اشرف", ParentPhone = "376467477" },
                                              new Student { Name = "سيد", Address = "ببا", Age = 20, Phone = "376467477", GradeID = 11, ParentName = "على", ParentPhone = "376467477" },
                                              new Student { Name = "اشرف", Address = "الواسطى", Age = 20, Phone = "376467477", GradeID = 5, ParentName = "احمد", ParentPhone = "376467477" },
                                              new Student { Name = "حسين", Address = "أشمنت", Age = 20, Phone = "376467477", GradeID = 21, ParentName = "محمد", ParentPhone = "376467477" },
                                              new Student { Name = "محسن", Address = "بنى سويف", Age = 20, Phone = "376467477", GradeID = 22, ParentName = "حسين", ParentPhone = "376467477" },
                                              new Student { Name = "خالد", Address = "ببا", Age = 20, Phone = "376467477", GradeID = 13, ParentName = "على", ParentPhone = "376467477" });
                }


                context.SaveChanges();
            }
        }
    }
}
