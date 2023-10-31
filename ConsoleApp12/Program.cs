using Ionic.Zip;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;

namespace HelloApp
{
  public class Humanity
  {
    public List<Person> people { get; set; }
  }
  public class Person
  {
    public int Age { get; set; }
    public string Name { get; set; }
    //public string SummaryField;
    public work Work { get; set; }
    public car Car { get; set; }
  }
  public class work
  {
    public string Company { get; set;}
    public string Job_title { get; set;}
  }
  public class car
  {
    public string Model { get; set; }
    public string Number { get; set; }
    public string Color { get; set; }
  }

  public class HighLowTemps
  {
    public int High { get; set; }
    public int Low { get; set; }
  }

  public class Program
  {
    public static async Task Main()
    {
      string name, model, number, color, job_title, company;
      int age;
      DriveInfo[] drives = DriveInfo.GetDrives();
      foreach (DriveInfo drive in drives)
      {
        Console.WriteLine($"Название: {drive.Name}");
        Console.WriteLine($"Тип: {drive.DriveType}");
        if (drive.IsReady)
        {
          Console.WriteLine($"Объем диска: {drive.TotalSize}");
          Console.WriteLine($"Свободное пространство: {drive.TotalFreeSpace}");
          Console.WriteLine($"Метка: {drive.VolumeLabel}");
        } Console.WriteLine();
      }
      Console.WriteLine("Введите полное имя файла");
      string fileName = Console.ReadLine();
      Console.WriteLine("Введите строку");
      string text = Console.ReadLine();
      if (File.Exists(fileName))
      {
        using (StreamWriter sw = new StreamWriter(new FileStream(fileName, FileMode.Append, FileAccess.Write)))
        {
          sw.WriteLine(text);
          sw.Close();
        }
      }
      else
      {
        using (StreamWriter sw = new StreamWriter(new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write)))
        {
          sw.WriteLine(text);
          sw.Close();
        }
      }
      var dstEncoding = Encoding.UTF8;
      using (StreamReader sr = new StreamReader(fileName,encoding:dstEncoding))
      {
        string line;
        Console.WriteLine("Текст из файла:");
        while ((line = sr.ReadLine()) != null)
        {
          Console.WriteLine(line);
        }
      }
      Console.WriteLine("Если вы хотите удалить файл напишите 'del' ");
      string ans = Console.ReadLine();
      if (ans == "del")
      {
        File.Delete(fileName);
      }
      Console.WriteLine("Введите полное имя json файла");
      string filename2 = Console.ReadLine();

      if (!File.Exists(filename2))
      {
        Console.WriteLine("Введите возраст");
        age = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Введите имя");
        name = Console.ReadLine();
        Console.WriteLine("Введите марку машины");
        model = Console.ReadLine();
        Console.WriteLine("Введите цвет машины");
        color = Console.ReadLine();
        Console.WriteLine("Введите номер машины");
        number = Console.ReadLine();
        Console.WriteLine("Введите компанию, где вы работаете");
        company = Console.ReadLine();
        Console.WriteLine("Введите должность");
        job_title = Console.ReadLine();
        string s = "Hooot";
        var weatherForecast = new Humanity
        { people = new List<Person>()
      {new Person(){
        Age = age,
        Name = name,
        Car = new car() {Model=model,Number=number,Color=color},
        Work = new work() {Job_title=job_title,Company=company}
        }
       }
        };
        var options1 = new JsonSerializerOptions
        {
          Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
          WriteIndented = true
        };
        string jsonString = JsonSerializer.Serialize(weatherForecast, options1);
        File.WriteAllText(filename2, jsonString);
      }
      Humanity persons;
      using (FileStream fs = new FileStream(filename2, FileMode.OpenOrCreate))
      {
        persons = await JsonSerializer.DeserializeAsync<Humanity>(fs);
        //Console.WriteLine($"Name: {people?.people[0].Name}  Age: {people?.people[0].Age}");
      }
      Console.WriteLine("Введите возраст");
      age = Convert.ToInt32(Console.ReadLine());
      Console.WriteLine("Введите имя");
      name = Console.ReadLine();
      Console.WriteLine("Введите марку машины");
      model = Console.ReadLine();
      Console.WriteLine("Введите цвет машины");
      color = Console.ReadLine();
      Console.WriteLine("Введите номер машины");
      number = Console.ReadLine();
      Console.WriteLine("Введите компанию, где вы работаете");
      company = Console.ReadLine();
      Console.WriteLine("Введите должность");
      job_title = Console.ReadLine();
      persons.people.Add(new Person()
      {
        Age = age,
        Name = name,
        Car = new car() { Model = model, Number = number, Color = color },
        Work = new work() { Job_title = job_title, Company = company }
      });
      var options2 = new JsonSerializerOptions
      {
        Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
        WriteIndented = true
      };
      string jsonString2 = JsonSerializer.Serialize(persons, options2);
      File.WriteAllText(filename2, jsonString2);
      using (FileStream fs = new FileStream(filename2, FileMode.OpenOrCreate))
      {
        persons = await JsonSerializer.DeserializeAsync<Humanity>(fs);
        int i = 0;
        foreach (Person ws in persons.people)
        {
          i++;
          Console.WriteLine($"Объект {i} ");
          Console.WriteLine($"Имя: {ws?.Name}");
          Console.WriteLine($"Возраст: {ws?.Age}");
          Console.WriteLine($"Марка машины: {ws?.Car.Model}");
          Console.WriteLine($"Цвет машины: {ws?.Car.Color}");
          Console.WriteLine($"Номер машины: {ws?.Car.Number}");
          Console.WriteLine($"Компания: {ws?.Work.Company}");
          Console.WriteLine($"Должность: {ws?.Work.Job_title}");
        }
        //Console.WriteLine($"Name: {people?.people[0].Name}  Age: {people?.people[0].Age}");
      }
      Console.WriteLine("Если вы хотите удалить файл напишите 'del' ");
      string ans2 = Console.ReadLine();
      if (ans2 == "del")
      {
        File.Delete(filename2);
      }
      Console.WriteLine("Введите полное имя xml файла");
      string filename3 = Console.ReadLine();
      while (!File.Exists(filename3))
      {
        Console.WriteLine("такого файла не существует, введите верное имя файла");
        filename3 = Console.ReadLine();
      }
      var humanity = new Humanity();
      System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(humanity.GetType());
      using (FileStream fs = new FileStream(filename3, FileMode.OpenOrCreate))
      {
        humanity = x.Deserialize(fs) as Humanity;
      }
      //Console.WriteLine(humanity.people[0].Age);
      Console.WriteLine("Введите возраст");
      age = Convert.ToInt32(Console.ReadLine());
      Console.WriteLine("Введите имя");
      name = Console.ReadLine();
      Console.WriteLine("Введите марку машины");
      model = Console.ReadLine();
      Console.WriteLine("Введите цвет машины");
      color = Console.ReadLine();
      Console.WriteLine("Введите номер машины");
      number = Console.ReadLine();
      Console.WriteLine("Введите компанию, где вы работаете");
      company = Console.ReadLine();
      Console.WriteLine("Введите должность");
      job_title = Console.ReadLine();
      humanity.people.Add(new Person()
      {
        Age = age,
        Name = name,
        Car = new car() { Model = model, Number = number, Color = color },
        Work = new work() { Job_title = job_title, Company = company }
      });
      using (FileStream fs = new FileStream(@"C:\Users\mmban\OneDrive\Documents\РАБОТА\xx.xml", FileMode.OpenOrCreate))
      {
        x.Serialize(fs, humanity);
      }
      using (FileStream fs = new FileStream(@"C:\Users\mmban\OneDrive\Documents\РАБОТА\xx.xml", FileMode.OpenOrCreate))
      {
        humanity = x.Deserialize(fs) as Humanity;
        int i = 0;
        foreach (Person ws in humanity.people)
        {
          i++;
          Console.WriteLine($"Объект {i} ");
          Console.WriteLine($"Имя: {ws?.Name}");
          Console.WriteLine($"Возраст: {ws?.Age}");
          Console.WriteLine($"Марка машины: {ws?.Car.Model}");
          Console.WriteLine($"Цвет машины: {ws?.Car.Color}");
          Console.WriteLine($"Номер машины: {ws?.Car.Number}");
          Console.WriteLine($"Компания: {ws?.Work.Company}");
          Console.WriteLine($"Должность: {ws?.Work.Job_title}");
        }
      }
      Console.WriteLine("Если вы хотите удалить файл напишите 'del' ");
      ans2 = Console.ReadLine();
      if (ans2 == "del")
      {
        File.Delete(filename3);
      }
      Console.WriteLine("Введите полное имя zip файла");
      string filename4 = Console.ReadLine();
      using (ZipFile zip = new ZipFile())
        { 
          zip.Save(filename4);
        }
      Console.WriteLine("Введите полное имя файла который вы хотите добавить");
      string filename5 = Console.ReadLine();
      using (ZipFile zip = new ZipFile(filename4))
      {
        zip.AddFile(filename5,"");
        zip.Save();
      }
      string fname  = Path.GetFileName(filename5);
      //Console.WriteLine(fname);
      Console.WriteLine("Введите директорию куда вы хотите вывести файл");
      string dir = Console.ReadLine();
      using (ZipFile zip = ZipFile.Read(filename4))
      {
        ZipEntry e = zip[fname];
        e.Extract(dir);
      }
      Console.WriteLine($"Дата создания файла {File.GetCreationTime(dir +@"\"+ fname)}");
      Console.WriteLine($"Дата последнего обращения к файлу {File.GetLastAccessTime(dir+ @"\" + fname)}");
      FileInfo fi = new FileInfo(dir + @"\" + fname);
      Console.WriteLine($"Размер файла {fi.Length}");
      Console.ReadKey();
    }
  }
}


