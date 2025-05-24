using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using PersonnelDepartmentApp.Models;

namespace PersonnelDepartmentApp.Services
{
    public class EducationRepository
    {
        private readonly string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "educations.json");

        public List<Education> LoadEducations()
        {
            if (!File.Exists(filePath))
                return new List<Education>();
            var json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<Education>>(json) ?? new List<Education>();
        }

        public void SaveEducations(List<Education> educations)
        {
            var json = JsonConvert.SerializeObject(educations, Formatting.Indented);
            File.WriteAllText(filePath, json);
        }
    }
}
