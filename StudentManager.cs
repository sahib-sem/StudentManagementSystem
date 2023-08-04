using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Reflection;

namespace StudentManagementSystem
{
    internal class StudentManager<T>
    {

        // add stundent 
        // search for student 
        // display list of students
        // save student data to json file
        // load student data from json file
        private string filePath;

        public StudentManager(string filePath)
        {
            this.filePath = filePath;
        }

        public  List<T> LoadData()
        {
            
                string json = File.ReadAllText(filePath);
              
                List<T> deserializedObject = JsonSerializer.Deserialize<List<T>>(json);

                return deserializedObject;
               
            
           

        }

        public void SaveData(List<T> objs)
        {
            string json = JsonSerializer.Serialize<List<T>>(objs);
           
            File.WriteAllText(filePath, json);
            
            
           


        }

        public void Add(T obj)
        {

            
            if (obj != null)
            {
                
                List<T> list = LoadData();
                list.Add(obj);
                SaveData(list);
            }

        }
        
        public bool search(string name)
        {
            List<T> allObjs = LoadData();
            var filteredData = allObjs.Where((data) =>
            {
                if(HasProperty(data, "Name"))
                {
                    Console.WriteLine("has the property");
                    string propertyValue = GetPropertyValue(data, "Name").ToString();
                  
                    
                    if(propertyValue == name)
                    {
                        Console.WriteLine("true");
                        return true;
                    }
                    return false;
                }
                return false;
                

            }).ToList();
            Console.WriteLine(filteredData.Count);
            if (filteredData != null)
            {
                this.listAll(filteredData);
                return true;
            }
            else
            {
                return false;

            }
            

        }

        public async Task listAll(List<T> objs)
      
        {
            Console.WriteLine("______________________________________________________");
            Console.WriteLine("you have the following students");
            foreach(var obj in objs)
            {
                Console.WriteLine(obj);
            }
            Console.WriteLine("______________________________________________________");

        }
        private static bool HasProperty(object obj, string propertyName)
        {
            return obj.GetType().GetProperty(propertyName) != null;
        }
        private static object GetPropertyValue(object obj, string propertyName)
        {
            PropertyInfo propertyInfo = obj.GetType().GetProperty(propertyName);
            return propertyInfo?.GetValue(obj);
        }
    }
}
