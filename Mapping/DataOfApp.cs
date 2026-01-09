using Mapping.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapping
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
                    context.Teachers.AddRange(new Teacher { Name = "محمد أحمد عبدالمنعم", Address = "الواسطى", Age = 21, Phone = "01155619453", Faculty = "حاسبات" },
                                              new Teacher { Name = "يوسف محمد أحمد ", Address = "ناصر - بوش", Age = 22,  Phone = "01559811659", Faculty = "ذوى احتياجات" },
                                              new Teacher { Name = "عبدالرحمن ابراهيم", Address = "الحمرايا", Age = 23,  Phone = "01559952586", Faculty = "خريج السن انجليزى" },
                                              new Teacher { Name = "زينب حسين", Address = "الواسطى - ميدوم", Age = 23,   Phone = "01157289257", Faculty = "خريجة اداب لغة عربية" },
                                              new Teacher { Name = "زبيده محمد", Address = "الثانوية العسكرية", Age = 41, Phone = "01114425095", Faculty = "خريجة" },
                                              new Teacher { Name = "رحمه صلاح", Address = "اهناسيا", Age = 0, Phone = "01146401002", Faculty = "خريجة" },
                                              new Teacher { Name = "ملوك مصطفى", Address = "البشري- طريق الفيوم", Age = 20, Phone = "01014124377", Faculty = "اداب لغة عربية" },
                                              new Teacher { Name = "منار أحمد فؤاد", Address = "عبدالسلام عارف- مديرية التموين", Age = 0, Phone = "01152002673", Faculty = "خريجة" },
                                              new Teacher { Name = "روميساء عبدالله", Address = "الدوية", Age = 22, Phone = "01274704244", Faculty = "تربية رياضية" },
                                              new Teacher { Name = "شروق حسين", Address = "غير معروف", Age = 22, Phone = "01010643925", Faculty = "إعلام" },
                                              new Teacher { Name = "بسملة عماد", Address = "الشرق", Age = 22, Phone = "01070499482", Faculty = "علاج طبيعي" },
                                              new Teacher { Name = "شهد عزت", Address = "غير معروف", Age = 0, Phone = "01027818688", Faculty = "تربية-كيمياء" },
                                              new Teacher { Name = "روان عصام", Address = "الدوية", Age = 0, Phone = "01129796583", Faculty = "زراعة" },
                                              new Teacher { Name = "حورية عيد", Address = "الجزيرة", Age = 20, Phone = "01030295895", Faculty = "إعلام" },
                                              new Teacher { Name = "آية ميهوب", Address = "غير معروف", Age = 0, Phone = "01007560892", Faculty = "خريجة" },
                                              new Teacher { Name = "هيام فرحات", Address = "الواسطى", Age = 0, Phone = "01112304387", Faculty = "خريجة اداب لغة عربية" },
                                              new Teacher { Name = "إيمان فرحات", Address = "الواسطى", Age = 0, Phone = "01126715014", Faculty = "خريجة اداب لغة عربية" },
                                              new Teacher { Name = "أسماء بدوي", Address = "ناصر- بوش", Age = 25, Phone = "01220468228", Faculty = "خريجة ذوي احتياجات خاصة" },
                                              new Teacher { Name = "أسماء عبد العاطي", Address = "ناصر- بوش", Age = 24, Phone = "01286360903", Faculty = "خريجة إعلام" },
                                              new Teacher { Name = "محمود أيمن", Address = "غير معروف", Age = 23, Phone = "1022027944", Faculty = "طب بيطري" });
                }

                //Subjects
                if (subjects)
                {
                    context.Subjects.AddRange(new Subject { Name = " عربى اولى ابتدائى", GradeId = 1, TeacherId = 1 },       // P-1
                                            new Subject { Name = "انجليزى اولى ابتدائى", GradeId = 1, TeacherId = 2 },
                                            new Subject { Name = "حساب اولى ابتدائى", GradeId = 1, TeacherId = 3 },
                                            new Subject { Name = "برايل اولى ابتدائى", GradeId = 1, TeacherId = 4 },
                                            new Subject { Name = "قراءة اولى ابتدائى", GradeId = 1 },
                                            new Subject { Name = "كتابة اولى ابتدائى", GradeId = 1 },

                                            new Subject { Name = "عربى تانية ابتدائى", GradeId = 2, TeacherId = 5 },      // P-2
                                            new Subject { Name = "انجليزى تانية ابتدائى", GradeId = 2, TeacherId = 6 },
                                            new Subject { Name = "حساب تانية ابتدائى", GradeId = 2, TeacherId = 7 },
                                            new Subject { Name = "برايل تانية ابتدائى", GradeId = 2, TeacherId = 1 },
                                            new Subject { Name = "قراءة تانية ابتدائى", GradeId = 2 },
                                            new Subject { Name = "كتابة تانية ابتدائى", GradeId = 2 },

                                            new Subject { Name = "عربى تالتة ابتدائى", GradeId = 3, TeacherId = 1 },      // P-3
                                            new Subject { Name = "انجليزى تالتة ابتدائى", GradeId = 3, TeacherId = 4 },
                                            new Subject { Name = "حساب تالتة ابتدائى", GradeId = 3, TeacherId = 4 },
                                            new Subject { Name = "برايل تالتة ابتدائى", GradeId = 3, TeacherId = 7 },
                                            new Subject { Name = "قراءة تالتة ابتدائى", GradeId = 3 },
                                            new Subject { Name = "كتابة تالتة ابتدائى", GradeId = 3 },

                                            new Subject { Name = "عربى رابعة ابتدائى", GradeId = 4, TeacherId = 8 },      // P-4
                                            new Subject { Name = "انجليزى رابعة ابتدائى", GradeId = 4, TeacherId = 2 },
                                            new Subject { Name = "حساب رابعة ابتدائى", GradeId = 4, TeacherId = 3 },
                                            new Subject { Name = "برايل رابعة ابتدائى", GradeId = 4, TeacherId = 6 },
                                            new Subject { Name = "قراءة رابعة ابتدائى", GradeId = 4 },
                                            new Subject { Name = "كتابة رابعة ابتدائى", GradeId = 4 },
                                            new Subject { Name = "علوم رابعة ابتدائى", GradeId = 4, TeacherId = 6 },
                                            new Subject { Name = "درسات رابعة ابتدائى", GradeId = 4, TeacherId = 6 },


                                            new Subject { Name = "عربى خامسة ابتدائى", GradeId = 5, TeacherId = 5 },      // P-5
                                            new Subject { Name = "انجليزى خامسة ابتدائى", GradeId = 5, TeacherId = 1 },
                                            new Subject { Name = "حساب خامسة ابتدائى", GradeId = 5, TeacherId = 4 },
                                            new Subject { Name = "برايل خامسة ابتدائى", GradeId = 5, TeacherId = 2 },
                                            new Subject { Name = "قراءة خامسة ابتدائى", GradeId = 5 },
                                            new Subject { Name = "كتابة خامسة ابتدائى", GradeId = 5 },
                                            new Subject { Name = "علوم خامسة ابتدائى", GradeId = 5, TeacherId = 2 },
                                            new Subject { Name = "درسات خامسة ابتدائى", GradeId = 5, TeacherId = 2 },


                                            new Subject { Name = "عربى الصف السادس الابتدائى", GradeId = 6, TeacherId = 3 },      // P-6
                                            new Subject { Name = "انجليزى الصف السادس الابتدائى", GradeId = 6, TeacherId = 1 },
                                            new Subject { Name = "حساب الصف السادس الابتدائى", GradeId = 6, TeacherId = 7 },
                                            new Subject { Name = "برايل الصف السادس الابتدائى", GradeId = 6, TeacherId = 3 },
                                            new Subject { Name = "قراءة الصف السادس الابتدائى", GradeId = 6 },
                                            new Subject { Name = "كتابة الصف السادس الابتدائى", GradeId = 6 },
                                            new Subject { Name = "علوم الصف السادس الابتدائى", GradeId = 6, TeacherId = 3 },
                                            new Subject { Name = "درسات الصف السادس الابتدائى", GradeId = 6, TeacherId = 3 },



                                             new Subject { Name = "عربى اولى اعدادى", GradeId = 11, TeacherId = 2 },
                                             new Subject { Name = "انجليزى اولى اعدادى", GradeId = 11, TeacherId = 2 },   // M-1
                                             new Subject { Name = "رياضيات اولى اعدادى", GradeId = 11, TeacherId = 3 },
                                             new Subject { Name = "برايل اولى اعدادى", GradeId = 11, TeacherId = 4 },
                                             new Subject { Name = "قراءة اولى اعدادى", GradeId = 11 },
                                             new Subject { Name = "كتابة اولى اعدادى", GradeId = 11 },
                                             new Subject { Name = "علوم اولى اعدادى", GradeId = 11, TeacherId = 4 },
                                             new Subject { Name = "درسات اولى اعدادى", GradeId = 11, TeacherId = 4 },

                                             new Subject { Name = "عربى تانية اعدادى", GradeId = 12, TeacherId = 5 },      // m-2
                                             new Subject { Name = "انجليزى تانية اعدادى", GradeId = 12, TeacherId = 6 },
                                             new Subject { Name = "رياضيات تانية اعدادى", GradeId = 12, TeacherId = 7 },
                                             new Subject { Name = "برايل تانية اعدادى", GradeId = 12, TeacherId = 3 },
                                             new Subject { Name = "قراءة تانية اعدادى", GradeId = 12 },
                                             new Subject { Name = "كتابة تانية اعدادى", GradeId = 12 },
                                             new Subject { Name = "علوم تانية اعدادى", GradeId = 12, TeacherId = 3 },
                                             new Subject { Name = "درسات تانية اعدادى", GradeId = 12, TeacherId = 3 },


                                             new Subject { Name = "عربى تالتة اعدادى", GradeId = 13, TeacherId = 1 },      // m-3
                                             new Subject { Name = "انجليزى تالتة اعدادى", GradeId = 13, TeacherId = 4 },
                                             new Subject { Name = "رياضيات تالتة اعدادى", GradeId = 13, TeacherId = 4 },
                                             new Subject { Name = "برايل تالتة اعدادى", GradeId = 13, TeacherId = 7 },
                                             new Subject { Name = "قراءة تالتة اعدادى", GradeId = 13 },
                                             new Subject { Name = "كتابة تالتة اعدادى", GradeId = 13 },
                                             new Subject { Name = "علوم تالتة اعدادى", GradeId = 13, TeacherId = 7 },
                                             new Subject { Name = "درسات تالتة اعدادى", GradeId = 13, TeacherId = 7 },





                                             new Subject { Name = "عربى اولى ثانوى", GradeId = 21, TeacherId = 2 },
                                             new Subject { Name = "انجليزى اولى ثانوى", GradeId = 21, TeacherId = 2 },   // S-1
                                             new Subject { Name = "رياضيات اولى ثانوى", GradeId = 21, TeacherId = 3 },
                                             new Subject { Name = "برايل اولى ثانوى", GradeId = 21, TeacherId = 4 },
                                             new Subject { Name = "قراءة اولى ثانوى", GradeId = 21, },
                                             new Subject { Name = "كتابة اولى ثانوى", GradeId = 21, },
                                             new Subject { Name = "تاريخ/جغرافيا اولى ثانوى", GradeId = 21, TeacherId = 4 },
                                             new Subject { Name = "كيمياء اولى ثانوى", GradeId = 21, TeacherId = 4 },


                                             new Subject { Name = "عربى تانية ثانوى", GradeId = 22, TeacherId = 5 },      // S-2
                                             new Subject { Name = "انجليزى تانية ثانوى", GradeId = 22, TeacherId = 6 },
                                             new Subject { Name = "رياضيات تانية ثانوى", GradeId = 22, TeacherId = 7 },
                                             new Subject { Name = "برايل تانية ثانوى", GradeId = 22, TeacherId = 3 },
                                             new Subject { Name = "قراءة تانية ثانوى", GradeId = 22 },
                                             new Subject { Name = "كتابة تانية ثانوى", GradeId = 22 },
                                             new Subject { Name = "تاريخ/جغرافيا تانية ثانوى", GradeId = 22, TeacherId = 3 },
                                             new Subject { Name = "كيمياء تانية ثانوى", GradeId = 22, TeacherId = 3 },


                                             new Subject { Name = "عربى تالتة ثانوى", GradeId = 23, TeacherId = 1 },      // S-3
                                             new Subject { Name = "انجليزى تالتة ثانوى", GradeId = 23, TeacherId = 4 },
                                             new Subject { Name = "رياضيات تالتة ثانوى", GradeId = 23, TeacherId = 4 },
                                             new Subject { Name = "برايل تالتة ثانوى", GradeId = 23, TeacherId = 7 },
                                             new Subject { Name = "قراءة تالتة ثانوى", GradeId = 23 },
                                             new Subject { Name = "كتابة تالتة ثانوى", GradeId = 23 },
                                             new Subject { Name = "تاريخ/جغرافيا تالتة ثانوى", GradeId = 23, TeacherId = 7 },
                                             new Subject { Name = "كيمياء تالتة ثانوى", GradeId = 23, TeacherId = 7 });

                }

                //students
                if (students)
                {
                    context.Students.AddRange(new Student { Name = " محمد على رمضان", Address = "الواسطى", Age = 20, Phone = "376467477", GradeID = 1, ParentName = "على", ParentPhone = "376467477" },
                                              new Student { Name = "طه محمود عادل", Address = "أشمنت", Age = 20, Phone = "376467477", GradeID = 1, ParentName = "حسين", ParentPhone = "376467477" },
                                              new Student { Name = "كريم سيد حسن", Address = "أشمنت", Age = 20, Phone = "376467477", GradeID = 1, ParentName = "حسين", ParentPhone = "376467477" },
                                              new Student { Name = "عمر خالد صابر", Address = "أشمنت", Age = 20, Phone = "376467477", GradeID = 1, ParentName = "حسين", ParentPhone = "376467477" },
                                              new Student { Name = "احمد", Address = "أشمنت", Age = 20, Phone = "376467477", GradeID = 2, ParentName = "حسين", ParentPhone = "376467477" },
                                              new Student { Name = "على", Address = "بنى سويف", Age = 20, Phone = "376467477", GradeID = 6, ParentName = "اشرف", ParentPhone = "376467477" },
                                              new Student { Name = "سيد", Address = "ببا", Age = 20, Phone = "376467477", GradeID = 11, ParentName = "على", ParentPhone = "376467477" },
                                              new Student { Name = "اشرف", Address = "الواسطى", Age = 20, Phone = "376467477", GradeID = 5, ParentName = "احمد", ParentPhone = "376467477" },
                                              new Student { Name = "حسين", Address = "أشمنت", Age = 20, Phone = "376467477", GradeID = 21, ParentName = "محمد", ParentPhone = "376467477" },
                                              new Student { Name = "محسن", Address = "بنى سويف", Age = 20, Phone = "376467477", GradeID = 22, ParentName = "حسين", ParentPhone = "376467477" },
                                              new Student { Name = "خالد حسين اشرف", Address = "ببا", Age = 20, Phone = "376467477", GradeID = 13, ParentName = "على", ParentPhone = "376467477" },
                                              new Student { Name = "يوسف محمود نصر", Address = "ببا", Age = 20, Phone = "376467477", GradeID = 13, ParentName = "على", ParentPhone = "376467477" });
                }


                context.SaveChanges();
            }
        }
    }
}
