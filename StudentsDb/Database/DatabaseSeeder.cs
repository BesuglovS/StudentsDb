using StudentsDb.DomainClasses;
using StudentsDb.Repositories.Concrete;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;

namespace StudentsDb.Database
{
    public static class DatabaseSeeder
    {
        public async static Task ClearTables()
        {
            var stRepo = new StudentRepository();
            await stRepo.ClearTable();

            var sRepo = new SpecialityRepository();
            await sRepo.ClearTable();

            var fRepo = new FacultyRepository();
            await fRepo.ClearTable();
        }

        public async static Task SeedData1()
        {
            await ClearTables();

            var fRepo = new FacultyRepository();
            var f1 = new Faculty { Name = "Факультет математики и компьютерных наук" };
            var f2 = new Faculty { Name = "Философский факультет" };
            var f3 = new Faculty { Name = "Химико-биологический факультет" };
            var f4 = new Faculty { Name = "Экономический факультет" };            

            var faculties = new List<Faculty> {f1, f2, f3, f4};
            await fRepo.AddFacultiesAsync(faculties);

            var sRepo = new SpecialityRepository();
            var s1 = new Specialty { Name = "Прикладная математика и информатика", Faculty = f1 };
            var s2 = new Specialty { Name = "Философия", Faculty = f2 };
            var s3 = new Specialty { Name = "Биология", Faculty = f3 };
            var s4 = new Specialty { Name = "Экономика", Faculty = f4 };            
            var specialities = new List<Specialty> {s1, s2, s3, s4};
            await sRepo.AddSpecialitiesAsync(specialities);

            var stRepo = new StudentRepository();
            var st1 = new Student { Fio = "Иванов Иван Иваныч", Phone = "212-85-06", Address = "USSR", AdmissionYear = rnd.Next(2017, 2019), Specialty = specialities[rnd.Next(specialities.Count)] };
            var st2 = new Student { Fio = "Никитина Анастасия Богдановна", Phone = "212-85-07", Address = "USSR", AdmissionYear = rnd.Next(2017, 2019), Specialty = specialities[rnd.Next(specialities.Count)] };
            var st3 = new Student { Fio = "Трясило София Брониславовна", Phone = "212-85-08", Address = "USSR", AdmissionYear = rnd.Next(2017, 2019), Specialty = specialities[rnd.Next(specialities.Count)] };
            var st4 = new Student { Fio = "Никитин Валентин Сергеевич", Phone = "212-85-09", Address = "USSR", AdmissionYear = rnd.Next(2017, 2019), Specialty = specialities[rnd.Next(specialities.Count)] };
            var st5 = new Student { Fio = "Крюков Кирилл Тимурович", Phone = "212-85-10", Address = "USSR", AdmissionYear = rnd.Next(2017, 2019), Specialty = specialities[rnd.Next(specialities.Count)] };
            var st6 = new Student { Fio = "Волкова Злата Дмитриевна", Phone = "212-85-11", Address = "USSR", AdmissionYear = rnd.Next(2017, 2019), Specialty = specialities[rnd.Next(specialities.Count)] };
            var st7 = new Student { Fio = "Родионов Максим Олегович", Phone = "212-85-12", Address = "USSR", AdmissionYear = rnd.Next(2017, 2019), Specialty = specialities[rnd.Next(specialities.Count)] };
            var st8 = new Student { Fio = "Орлова Валерия Вадимовна", Phone = "212-85-03", Address = "USSR", AdmissionYear = rnd.Next(2017, 2019), Specialty = specialities[rnd.Next(specialities.Count)] };
            var st9 = new Student { Fio = "Токар Елена Викторовна", Phone = "212-85-14", Address = "USSR", AdmissionYear = rnd.Next(2017, 2019), Specialty = specialities[rnd.Next(specialities.Count)] };
            var students = new List<Student> {st1, st2, st3, st4, st5, st6, st7, st8, st9};
            await stRepo.AddStudentsAsync(students);

            MessageBox.Show("Набор данных 1 внесён.", "Готово");
        }

        public async static Task SeedData2()
        {
            await ClearTables();

            var fRepo = new FacultyRepository();
            var f1 = new Faculty { Name = "Факультет математики и компьютерных наук" };
            var f2 = new Faculty { Name = "Философский факультет" };
            var f3 = new Faculty { Name = "Химико-биологический факультет" };
            var f4 = new Faculty { Name = "Экономический факультет" };
            var f5 = new Faculty { Name = "Юридический факультет" };
            var f6 = new Faculty { Name = "Факультет международных отношений" };
            var f7 = new Faculty { Name = "Факультет управления" };
            var f8 = new Faculty { Name = "Факультет искусств" };
            var f9 = new Faculty { Name = "Факультет туризма" };

            var faculties = new List<Faculty> { f1, f2, f3, f4, f5, f6, f7, f8, f9 };
            await fRepo.AddFacultiesAsync(faculties);

            var sRepo = new SpecialityRepository();
            var s1 = new Specialty { Name = "Прикладная математика и информатика", Faculty = f1 };
            var s2 = new Specialty { Name = "Философия", Faculty = f2 };
            var s3 = new Specialty { Name = "Биология", Faculty = f3 };
            var s4 = new Specialty { Name = "Экономика", Faculty = f4 };
            var s5 = new Specialty { Name = "Юриспруденция", Faculty = f5 };
            var s6 = new Specialty { Name = "Реклама и связи с общественностью", Faculty = f6 };
            var s7 = new Specialty { Name = "Управление качеством", Faculty = f7 };
            var s8 = new Specialty { Name = "Актерское искусство", Faculty = f8 };
            var s9 = new Specialty { Name = "Туризм", Faculty = f9 };

            var s11 = new Specialty { Name = "Математика", Faculty = f1 };
            var s12 = new Specialty { Name = "Прикладная этика", Faculty = f2 };
            var s13 = new Specialty { Name = "Почвоведение", Faculty = f3 };
            var s14 = new Specialty { Name = "Менеджмент", Faculty = f4 };
            var s15 = new Specialty { Name = "Политология", Faculty = f5 };
            var s16 = new Specialty { Name = "Издательское дело", Faculty = f6 };
            var s17 = new Specialty { Name = "Стандартизация и метрология", Faculty = f7 };
            var s18 = new Specialty { Name = "Режиссура театра", Faculty = f8 };
            var s19 = new Specialty { Name = "Сервис", Faculty = f9 };
            var specialities = new List<Specialty> { s1, s2, s3, s4, s5, s6, s7, s8, s9, s11, s12, s13, s14, s16, s17, s18, s19 };
            await sRepo.AddSpecialitiesAsync(specialities);

            var stRepo = new StudentRepository();
            var st1 = new Student { Fio = "Легойда Август Богданович", Phone = "212-85-01", Address = "USSR", AdmissionYear = rnd.Next(2014, 2019), Specialty = specialities[rnd.Next(specialities.Count)] };
            var st2 = new Student { Fio = "Савин Елисей Платонович", Phone = "212-85-02", Address = "USSR", AdmissionYear = rnd.Next(2014, 2019), Specialty = specialities[rnd.Next(specialities.Count)] };
            var st3 = new Student { Fio = "Бердник Гордей Андреевич", Phone = "212-85-03", Address = "USSR", AdmissionYear = rnd.Next(2014, 2019), Specialty = specialities[rnd.Next(specialities.Count)] };
            var st4 = new Student { Fio = "Корнилов Евгений Станиславович", Phone = "212-85-04", Address = "USSR", AdmissionYear = rnd.Next(2014, 2019), Specialty = specialities[rnd.Next(specialities.Count)] };
            var st5 = new Student { Fio = "Шевченко Ростислав Фёдорович", Phone = "212-85-05", Address = "USSR", AdmissionYear = rnd.Next(2014, 2019), Specialty = specialities[rnd.Next(specialities.Count)] };
            var st6 = new Student { Fio = "Жуков Евстахий Анатолиевич", Phone = "212-85-06", Address = "USSR", AdmissionYear = rnd.Next(2014, 2019), Specialty = specialities[rnd.Next(specialities.Count)] };
            var st7 = new Student { Fio = "Романенко Владимир Иванович", Phone = "212-85-07", Address = "USSR", AdmissionYear = rnd.Next(2014, 2019), Specialty = specialities[rnd.Next(specialities.Count)] };
            var st8 = new Student { Fio = "Житар Вениамин Васильевич", Phone = "212-85-08", Address = "USSR", AdmissionYear = rnd.Next(2014, 2019), Specialty = specialities[rnd.Next(specialities.Count)] };
            var st9 = new Student { Fio = "Горбунов Фёдор Андреевич", Phone = "212-85-09", Address = "USSR", AdmissionYear = rnd.Next(2014, 2019), Specialty = specialities[rnd.Next(specialities.Count)] };
            var st10 = new Student { Fio = "Савельев Огюст Максимович", Phone = "212-85-10", Address = "USSR", AdmissionYear = rnd.Next(2014, 2019), Specialty = specialities[rnd.Next(specialities.Count)] };
            var st11 = new Student { Fio = "Моисеенко Клаус Максимович", Phone = "212-85-11", Address = "USSR", AdmissionYear = rnd.Next(2014, 2019), Specialty = specialities[rnd.Next(specialities.Count)] };
            var st12 = new Student { Fio = "Козлов Артур Васильевич", Phone = "212-85-12", Address = "USSR", AdmissionYear = rnd.Next(2014, 2019), Specialty = specialities[rnd.Next(specialities.Count)] };
            var st13 = new Student { Fio = "Зимин Осип Михайлович", Phone = "212-85-13", Address = "USSR", AdmissionYear = rnd.Next(2014, 2019), Specialty = specialities[rnd.Next(specialities.Count)] };
            var st14 = new Student { Fio = "Селезнёв Иммануил Борисович", Phone = "212-85-14", Address = "USSR", AdmissionYear = rnd.Next(2014, 2019), Specialty = specialities[rnd.Next(specialities.Count)] };
            var st15 = new Student { Fio = "Савенко Иммануил Леонидович", Phone = "212-85-15", Address = "USSR", AdmissionYear = rnd.Next(2014, 2019), Specialty = specialities[rnd.Next(specialities.Count)] };
            var st16 = new Student { Fio = "Владимиров Гарри Андреевич", Phone = "212-85-16", Address = "USSR", AdmissionYear = rnd.Next(2014, 2019), Specialty = specialities[rnd.Next(specialities.Count)] };
            var st17 = new Student { Fio = "Рогов Леон Грегориевич", Phone = "212-85-17", Address = "USSR", AdmissionYear = rnd.Next(2014, 2019), Specialty = specialities[rnd.Next(specialities.Count)] };
            var st18 = new Student { Fio = "Козлов Ефим Викторович", Phone = "212-85-18", Address = "USSR", AdmissionYear = rnd.Next(2014, 2019), Specialty = specialities[rnd.Next(specialities.Count)] };
            var st19 = new Student { Fio = "Кличко Иосиф Сергеевич", Phone = "212-85-19", Address = "USSR", AdmissionYear = rnd.Next(2014, 2019), Specialty = specialities[rnd.Next(specialities.Count)] };
            var st20 = new Student { Fio = "Ширяев Владлен Данилович", Phone = "212-85-20", Address = "USSR", AdmissionYear = rnd.Next(2014, 2019), Specialty = specialities[rnd.Next(specialities.Count)] };
            var st21 = new Student { Fio = "Хижняк Валерий Иванович", Phone = "212-85-21", Address = "USSR", AdmissionYear = rnd.Next(2014, 2019), Specialty = specialities[rnd.Next(specialities.Count)] };
            var st22 = new Student { Fio = "Петровский Кузьма Брониславович", Phone = "212-85-22", Address = "USSR", AdmissionYear = rnd.Next(2014, 2019), Specialty = specialities[rnd.Next(specialities.Count)] };
            var st23 = new Student { Fio = "Никифоров Анатолий Грегориевич", Phone = "212-85-23", Address = "USSR", AdmissionYear = rnd.Next(2014, 2019), Specialty = specialities[rnd.Next(specialities.Count)] };
            var st24 = new Student { Fio = "Герасимов Владислав Богданович", Phone = "212-85-24", Address = "USSR", AdmissionYear = rnd.Next(2014, 2019), Specialty = specialities[rnd.Next(specialities.Count)] };
            var st25 = new Student { Fio = "Захарченко Феликс Вадимович", Phone = "212-85-25", Address = "USSR", AdmissionYear = rnd.Next(2014, 2019), Specialty = specialities[rnd.Next(specialities.Count)] };
            var st26 = new Student { Fio = "Скоропадский Евсей Фёдорович", Phone = "212-85-26", Address = "USSR", AdmissionYear = rnd.Next(2014, 2019), Specialty = specialities[rnd.Next(specialities.Count)] };
            var st27 = new Student { Fio = "Борисов Игорь Артёмович", Phone = "212-85-27", Address = "USSR", AdmissionYear = rnd.Next(2014, 2019), Specialty = specialities[rnd.Next(specialities.Count)] };
            var st28 = new Student { Fio = "Киселёв Феликс Львович", Phone = "212-85-28", Address = "USSR", AdmissionYear = rnd.Next(2014, 2019), Specialty = specialities[rnd.Next(specialities.Count)] };
            var st29 = new Student { Fio = "Симоненко Корнелий Брониславович", Phone = "212-85-29", Address = "USSR", AdmissionYear = rnd.Next(2014, 2019), Specialty = specialities[rnd.Next(specialities.Count)] };
            var st30 = new Student { Fio = "Петренко Андрей Фёдорович", Phone = "212-85-30", Address = "USSR", AdmissionYear = rnd.Next(2014, 2019), Specialty = specialities[rnd.Next(specialities.Count)] };
            var st31 = new Student { Fio = "Гриневская Ананий Евгеньевич", Phone = "212-85-31", Address = "USSR", AdmissionYear = rnd.Next(2014, 2019), Specialty = specialities[rnd.Next(specialities.Count)] };
            var st32 = new Student { Fio = "Ильин Константин Андреевич", Phone = "212-85-32", Address = "USSR", AdmissionYear = rnd.Next(2014, 2019), Specialty = specialities[rnd.Next(specialities.Count)] };
            var st33 = new Student { Fio = "Артемьев Тарас Станиславович", Phone = "212-85-33", Address = "USSR", AdmissionYear = rnd.Next(2014, 2019), Specialty = specialities[rnd.Next(specialities.Count)] };
            var st34 = new Student { Fio = "Гущин Зенон Александрович", Phone = "212-85-34", Address = "USSR", AdmissionYear = rnd.Next(2014, 2019), Specialty = specialities[rnd.Next(specialities.Count)] };
            var st35 = new Student { Fio = "Гамула Пётр Юхимович", Phone = "212-85-35", Address = "USSR", AdmissionYear = rnd.Next(2014, 2019), Specialty = specialities[rnd.Next(specialities.Count)] };
            var st36 = new Student { Fio = "Фёдоров Лаврентий Алексеевич", Phone = "212-85-36", Address = "USSR", AdmissionYear = rnd.Next(2014, 2019), Specialty = specialities[rnd.Next(specialities.Count)] };
            var st37 = new Student { Fio = "Корнейчук Тит Грегориевич", Phone = "212-85-37", Address = "USSR", AdmissionYear = rnd.Next(2014, 2019), Specialty = specialities[rnd.Next(specialities.Count)] };
            var st38 = new Student { Fio = "Доронин Иван Платонович", Phone = "212-85-38", Address = "USSR", AdmissionYear = rnd.Next(2014, 2019), Specialty = specialities[rnd.Next(specialities.Count)] };
            var st39 = new Student { Fio = "Зварыч Зиновий Леонидович", Phone = "212-85-39", Address = "USSR", AdmissionYear = rnd.Next(2014, 2019), Specialty = specialities[rnd.Next(specialities.Count)] };
            var st40 = new Student { Fio = "Яковенко Кузьма Эдуардович", Phone = "212-85-40", Address = "USSR", AdmissionYear = rnd.Next(2014, 2019), Specialty = specialities[rnd.Next(specialities.Count)] };
            var st41 = new Student { Fio = "Кабанов Конрад Андреевич", Phone = "212-85-41", Address = "USSR", AdmissionYear = rnd.Next(2014, 2019), Specialty = specialities[rnd.Next(specialities.Count)] };
            var st42 = new Student { Fio = "Карпов Адриан Данилович", Phone = "212-85-42", Address = "USSR", AdmissionYear = rnd.Next(2014, 2019), Specialty = specialities[rnd.Next(specialities.Count)] };
            var st43 = new Student { Fio = "Несвитайло Денис Данилович", Phone = "212-85-43", Address = "USSR", AdmissionYear = rnd.Next(2014, 2019), Specialty = specialities[rnd.Next(specialities.Count)] };
            var st44 = new Student { Fio = "Беляев Гавриил Алексеевич", Phone = "212-85-44", Address = "USSR", AdmissionYear = rnd.Next(2014, 2019), Specialty = specialities[rnd.Next(specialities.Count)] };
            var st45 = new Student { Fio = "Овчинников Валериан Анатолиевич", Phone = "212-85-45", Address = "USSR", AdmissionYear = rnd.Next(2014, 2019), Specialty = specialities[rnd.Next(specialities.Count)] };
            var st46 = new Student { Fio = "Харитонов Леопольд Сергеевич", Phone = "212-85-46", Address = "USSR", AdmissionYear = rnd.Next(2014, 2019), Specialty = specialities[rnd.Next(specialities.Count)] };
            var st47 = new Student { Fio = "Константинов Игорь Грегориевич", Phone = "212-85-47", Address = "USSR", AdmissionYear = rnd.Next(2014, 2019), Specialty = specialities[rnd.Next(specialities.Count)] };
            var st48 = new Student { Fio = "Поляков Зенон Артёмович", Phone = "212-85-48", Address = "USSR", AdmissionYear = rnd.Next(2014, 2019), Specialty = specialities[rnd.Next(specialities.Count)] };
            var st49 = new Student { Fio = "Воронов Евсей Платонович", Phone = "212-85-49", Address = "USSR", AdmissionYear = rnd.Next(2014, 2019), Specialty = specialities[rnd.Next(specialities.Count)] };
            var st50 = new Student { Fio = "Овчаренко Юрий Максимович", Phone = "212-85-50", Address = "USSR", AdmissionYear = rnd.Next(2014, 2019), Specialty = specialities[rnd.Next(specialities.Count)] };
            var st51 = new Student { Fio = "Кулибаба Анна Юхимовна", Phone = "212-85-51", Address = "USSR", AdmissionYear = rnd.Next(2014, 2019), Specialty = specialities[rnd.Next(specialities.Count)] };
            var st52 = new Student { Fio = "Бутко Надежда Станиславовна", Phone = "212-85-52", Address = "USSR", AdmissionYear = rnd.Next(2014, 2019), Specialty = specialities[rnd.Next(specialities.Count)] };
            var st53 = new Student { Fio = "Федункив Полина Анатолиевна", Phone = "212-85-53", Address = "USSR", AdmissionYear = rnd.Next(2014, 2019), Specialty = specialities[rnd.Next(specialities.Count)] };
            var st54 = new Student { Fio = "Николаева Ника Андреевна", Phone = "212-85-54", Address = "USSR", AdmissionYear = rnd.Next(2014, 2019), Specialty = specialities[rnd.Next(specialities.Count)] };
            var st55 = new Student { Fio = "Анисимова Варвара Артёмовна", Phone = "212-85-55", Address = "USSR", AdmissionYear = rnd.Next(2014, 2019), Specialty = specialities[rnd.Next(specialities.Count)] };
            var st56 = new Student { Fio = "Самсонова Евгения Васильевна", Phone = "212-85-56", Address = "USSR", AdmissionYear = rnd.Next(2014, 2019), Specialty = specialities[rnd.Next(specialities.Count)] };
            var st57 = new Student { Fio = "Шумило Капитолина Анатолиевна", Phone = "212-85-57", Address = "USSR", AdmissionYear = rnd.Next(2014, 2019), Specialty = specialities[rnd.Next(specialities.Count)] };
            var st58 = new Student { Fio = "Тарасова Флорентина Леонидовна", Phone = "212-85-58", Address = "USSR", AdmissionYear = rnd.Next(2014, 2019), Specialty = specialities[rnd.Next(specialities.Count)] };
            var st59 = new Student { Fio = "Негода Клементина Александровна", Phone = "212-85-59", Address = "USSR", AdmissionYear = rnd.Next(2014, 2019), Specialty = specialities[rnd.Next(specialities.Count)] };
            var st60 = new Student { Fio = "Василенко Флорентина Дмитриевна", Phone = "212-85-60", Address = "USSR", AdmissionYear = rnd.Next(2014, 2019), Specialty = specialities[rnd.Next(specialities.Count)] };
            var st61 = new Student { Fio = "Молчанова Ярослава Максимовна", Phone = "212-85-61", Address = "USSR", AdmissionYear = rnd.Next(2014, 2019), Specialty = specialities[rnd.Next(specialities.Count)] };
            var st62 = new Student { Fio = "Бондаренко Клементина Васильевна", Phone = "212-85-62", Address = "USSR", AdmissionYear = rnd.Next(2014, 2019), Specialty = specialities[rnd.Next(specialities.Count)] };
            var st63 = new Student { Fio = "Батейко Людмила Дмитриевна", Phone = "212-85-63", Address = "USSR", AdmissionYear = rnd.Next(2014, 2019), Specialty = specialities[rnd.Next(specialities.Count)] };
            var st64 = new Student { Fio = "Большакова Дина Ярославовна", Phone = "212-85-64", Address = "USSR", AdmissionYear = rnd.Next(2014, 2019), Specialty = specialities[rnd.Next(specialities.Count)] };
            var st65 = new Student { Fio = "Орлова Валерия Вадимовна", Phone = "212-85-65", Address = "USSR", AdmissionYear = rnd.Next(2014, 2019), Specialty = specialities[rnd.Next(specialities.Count)] };
            var st66 = new Student { Fio = "Трясило София Брониславовна", Phone = "212-85-66", Address = "USSR", AdmissionYear = rnd.Next(2014, 2019), Specialty = specialities[rnd.Next(specialities.Count)] };
            var st67 = new Student { Fio = "Кондратьева Валерия Фёдоровна", Phone = "212-85-67", Address = "USSR", AdmissionYear = rnd.Next(2014, 2019), Specialty = specialities[rnd.Next(specialities.Count)] };
            var st68 = new Student { Fio = "Петухова Жанна Виталиевна", Phone = "212-85-68", Address = "USSR", AdmissionYear = rnd.Next(2014, 2019), Specialty = specialities[rnd.Next(specialities.Count)] };
            var st69 = new Student { Fio = "Сирко Эльвира Васильевна", Phone = "212-85-69", Address = "USSR", AdmissionYear = rnd.Next(2014, 2019), Specialty = specialities[rnd.Next(specialities.Count)] };
            var st70 = new Student { Fio = "Хохлова Анжелика Максимовна", Phone = "212-85-70", Address = "USSR", AdmissionYear = rnd.Next(2014, 2019), Specialty = specialities[rnd.Next(specialities.Count)] };
            var st71 = new Student { Fio = "Никифорова Оксана Брониславовна", Phone = "212-85-71", Address = "USSR", AdmissionYear = rnd.Next(2014, 2019), Specialty = specialities[rnd.Next(specialities.Count)] };
            var st72 = new Student { Fio = "Захарова Фаина Станиславовна", Phone = "212-85-72", Address = "USSR", AdmissionYear = rnd.Next(2014, 2019), Specialty = specialities[rnd.Next(specialities.Count)] };
            var st73 = new Student { Fio = "Зайцева Лада Борисовна", Phone = "212-85-73", Address = "USSR", AdmissionYear = rnd.Next(2014, 2019), Specialty = specialities[rnd.Next(specialities.Count)] };
            var st74 = new Student { Fio = "Волкова Злата Дмитриевна", Phone = "212-85-74", Address = "USSR", AdmissionYear = rnd.Next(2014, 2019), Specialty = specialities[rnd.Next(specialities.Count)] };
            var st75 = new Student { Fio = "Никитина Анастасия Богдановна", Phone = "212-85-75", Address = "USSR", AdmissionYear = rnd.Next(2014, 2019), Specialty = specialities[rnd.Next(specialities.Count)] };
            var st76 = new Student { Fio = "Никитина Екатерина Алексеевна", Phone = "212-85-76", Address = "USSR", AdmissionYear = rnd.Next(2014, 2019), Specialty = specialities[rnd.Next(specialities.Count)] };
            var st77 = new Student { Fio = "Кулакова Дина Даниловна", Phone = "212-85-77", Address = "USSR", AdmissionYear = rnd.Next(2014, 2019), Specialty = specialities[rnd.Next(specialities.Count)] };
            var st78 = new Student { Fio = "Корнилова Изабелла Петровна", Phone = "212-85-78", Address = "USSR", AdmissionYear = rnd.Next(2014, 2019), Specialty = specialities[rnd.Next(specialities.Count)] };
            var st79 = new Student { Fio = "Баранова Алёна Андреевна", Phone = "212-85-78", Address = "USSR", AdmissionYear = rnd.Next(2014, 2019), Specialty = specialities[rnd.Next(specialities.Count)] };
            var st80 = new Student { Fio = "Анисимова Мальвина Грегориевна", Phone = "212-85-80", Address = "USSR", AdmissionYear = rnd.Next(2014, 2019), Specialty = specialities[rnd.Next(specialities.Count)] };
            var st81 = new Student { Fio = "Ярова Анфиса Сергеевна", Phone = "212-85-81", Address = "USSR", AdmissionYear = rnd.Next(2014, 2019), Specialty = specialities[rnd.Next(specialities.Count)] };
            var st82 = new Student { Fio = "Федоренко Людмила Андреевна", Phone = "212-85-82", Address = "USSR", AdmissionYear = rnd.Next(2014, 2019), Specialty = specialities[rnd.Next(specialities.Count)] };
            var st83 = new Student { Fio = "Анисимова Ольга Вадимовна", Phone = "212-85-83", Address = "USSR", AdmissionYear = rnd.Next(2014, 2019), Specialty = specialities[rnd.Next(specialities.Count)] };
            var st84 = new Student { Fio = "Колесникова Рената Леонидовна", Phone = "212-85-84", Address = "USSR", AdmissionYear = rnd.Next(2014, 2019), Specialty = specialities[rnd.Next(specialities.Count)] };
            var st85 = new Student { Fio = "Федотова Рада Романовна", Phone = "212-85-85", Address = "USSR", AdmissionYear = rnd.Next(2014, 2019), Specialty = specialities[rnd.Next(specialities.Count)] };
            var st86 = new Student { Fio = "Романова Лилия Романовна", Phone = "212-85-86", Address = "USSR", AdmissionYear = rnd.Next(2014, 2019), Specialty = specialities[rnd.Next(specialities.Count)] };
            var st87 = new Student { Fio = "Несвитайло Виктория Виталиевна", Phone = "212-85-87", Address = "USSR", AdmissionYear = rnd.Next(2014, 2019), Specialty = specialities[rnd.Next(specialities.Count)] };
            var st88 = new Student { Fio = "Александрова Любовь Фёдоровна", Phone = "212-85-88", Address = "USSR", AdmissionYear = rnd.Next(2014, 2019), Specialty = specialities[rnd.Next(specialities.Count)] };
            var st89 = new Student { Fio = "Бородай Изольда Эдуардовна", Phone = "212-85-89", Address = "USSR", AdmissionYear = rnd.Next(2014, 2019), Specialty = specialities[rnd.Next(specialities.Count)] };
            var st90 = new Student { Fio = "Колобова Марта Богдановна", Phone = "212-85-90", Address = "USSR", AdmissionYear = rnd.Next(2014, 2019), Specialty = specialities[rnd.Next(specialities.Count)] };
            var st91 = new Student { Fio = "Самсонова Александра Александровна", Phone = "212-85-91", Address = "USSR", AdmissionYear = rnd.Next(2014, 2019), Specialty = specialities[rnd.Next(specialities.Count)] };
            var st92 = new Student { Fio = "Исакова Регина Васильевна", Phone = "212-85-92", Address = "USSR", AdmissionYear = rnd.Next(2014, 2019), Specialty = specialities[rnd.Next(specialities.Count)] };
            var st93 = new Student { Fio = "Токар Елена Викторовна", Phone = "212-85-93", Address = "USSR", AdmissionYear = rnd.Next(2014, 2019), Specialty = specialities[rnd.Next(specialities.Count)] };
            var st94 = new Student { Fio = "Калашникова Клара Михайловна", Phone = "212-85-94", Address = "USSR", AdmissionYear = rnd.Next(2014, 2019), Specialty = specialities[rnd.Next(specialities.Count)] };
            var st95 = new Student { Fio = "Гамула Маргарита Эдуардовна", Phone = "212-85-95", Address = "USSR", AdmissionYear = rnd.Next(2014, 2019), Specialty = specialities[rnd.Next(specialities.Count)] };
            var st96 = new Student { Fio = "Субботина Дина Даниловна", Phone = "212-85-98", Address = "USSR", AdmissionYear = rnd.Next(2014, 2019), Specialty = specialities[rnd.Next(specialities.Count)] };
            var st97 = new Student { Fio = "Панфилова Капитолина Евгеньевна", Phone = "212-85-97", Address = "USSR", AdmissionYear = rnd.Next(2014, 2019), Specialty = specialities[rnd.Next(specialities.Count)] };
            var st98 = new Student { Fio = "Масловска Инесса Фёдоровна", Phone = "212-85-98", Address = "USSR", AdmissionYear = rnd.Next(2014, 2019), Specialty = specialities[rnd.Next(specialities.Count)] };
            var st99 = new Student { Fio = "Чернова Рената Виталиевна", Phone = "212-85-99", Address = "USSR", AdmissionYear = rnd.Next(2014, 2019), Specialty = specialities[rnd.Next(specialities.Count)] };
            var st100 = new Student { Fio = "Миклашевска Анна Владимировна", Phone = "212-85-00", Address = "USSR", AdmissionYear = rnd.Next(2014, 2019), Specialty = specialities[rnd.Next(specialities.Count)] };

            var students = new List<Student> {
                st1, st2, st3, st4, st5, st6, st7, st8, st9, st10,
                st11, st12, st13, st14, st15, st16, st17, st18, st19, st20,
                st21, st22, st23, st24, st25, st26, st27, st28, st29, st30,
                st31, st32, st33, st34, st35, st36, st37, st38, st39, st40,
                st41, st42, st43, st44, st45, st46, st47, st48, st49, st50,
                st51, st52, st53, st54, st55, st56, st57, st58, st59, st60,
                st61, st62, st63, st64, st65, st66, st67, st68, st69, st70,
                st71, st72, st73, st74, st75, st76, st77, st78, st79, st80,
                st81, st82, st83, st84, st85, st86, st87, st88, st89, st90,
                st91, st92, st93, st94, st95, st96, st97, st98, st99, st100
            };
            students.Shuffle();

            await stRepo.AddStudentsAsync(students);

            MessageBox.Show("Набор данных 2 внесён.", "Готово");
        }

        public async static Task SeedData3()
        {
            await ClearTables();

            MessageBox.Show("Набор данных 3 (пустой) внесён.", "Готово");
        }

        private static Random rnd = new Random();

        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rnd.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
