using StringExtension;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LabWork_1_WPF
{
    public class IniController
    {
        /// <summary>
        /// [Student] (2nd level - Dictionary<string, Dictionary<string, object>>)
        /// Name = Vitalik (1st level - Dictionary<string, object>)
        /// Age = 18
        /// Group = M3204
        /// </summary>
        private Dictionary<string, Dictionary<string, object>> _info;
        private Dictionary<string, string> _comments;
        private string _filePath;

        public IniController(string filePath)
        {
            _filePath = filePath;
            _info = new Dictionary<string, Dictionary<string, object>>();
            _comments = new Dictionary<string, string>();
        }

        public int GetIntValue(string section, string key)
        {
            return Convert.ToInt32(_info[section][key]);
        }

        public double GetDoubleValue(string section, string key)
        {
            return Convert.ToDouble(_info[section][key]);
        }

        public string GetStringValue(string section, string key)
        {
            return _info[section][key].ToString();
        }

        public List<string> GetSections()
        {
            List<string> result = new List<string>();
            foreach (var key in _info.Keys) {
                result.Add(key);
            }
            return result;
        }

        public List<string> GetPairs(string section)
        {
            List<string> result = new List<string>();
            foreach (var pair in _info[section].Keys) {
                result.Add(pair);
            }
            return result;
        }

        // Секции в которых есть комментарии
        public List<string> GetOnlySectionComments()
        {
            List<string> result = new List<string>();
            foreach (var comment in _comments.Keys) {
                foreach (var section in GetSections()) {
                    if (comment == section && !result.Contains(section)) {
                        result.Add(section);
                    }
                }
            }
            return result;
        }

        public List<string> GetSectionWithComments()
        {
            List<string> result = new List<string>();
            foreach (var comment in _comments.Keys) {
                foreach (var section in GetSections()) {
                    if (comment.Contains(section) && !result.Contains(section)) {
                        result.Add(section);
                    }
                }
            }
            return result;
        }

        public List<string> GetPairComments(string section)
        {
            List<string> result = new List<string>();
            foreach (var comment in _comments.Keys) {
                foreach (var pair in GetPairs(section)) {
                    if (comment.Contains(pair) && !result.Contains(pair)) {
                        result.Add(pair);
                    }
                }
            }
            return result;
        }

        public void AddSection(string sectionName) => _info[sectionName] = new Dictionary<string, object>();
        public void DeleteSection(string sectionName)
        {
            foreach (var i in _comments.Keys) {
                if (i.Contains(sectionName)) {
                    _comments.Remove(i);
                }
            }
            _info.Remove(sectionName);
        }
        public void AddPair(string sectionName, string key, object value) => _info[sectionName].Add(key, value);
        public void DeletePair(string sectionName, string key)
        {
            foreach (var i in _comments.Keys) {
                if (i.Contains(key)) {
                    _comments.Remove(i);
                }
            }
            _info[sectionName].Remove(key);
        }

        public void AddSectionComment(string sectionName, string comment)
        {
            comment = "; " + comment;
            if (!_comments.ContainsKey(sectionName)) {
                _comments.Add(sectionName, comment);
            } else {
                _comments[sectionName] += ('\n' + comment);
            }
        }
        // Удаляет ВСЕ строки комментариев в секции
        public void DeleteSectionComment(string sectionName) => _comments.Remove(sectionName);
        public void AddPairComment(string sectionName, string pairKey, string comment)
        {
            comment = "; " + comment;
            if (!_comments.ContainsKey(sectionName + pairKey)) {
                _comments.Add(sectionName + pairKey, comment);
            } else {
                _comments[sectionName + pairKey] += comment;
            }
        }
        public void DeletePairComment(string sectionName, string pairKey) => _comments.Remove(sectionName + pairKey);

        public string GetFile()
        {
            string result = "";
            foreach (var section in _info) {
                result += $"[{section.Key}]\n";
                foreach (var pair in section.Value) {
                    if (_comments.ContainsKey(section.Key + pair.Key)) {
                        result += $"{pair.Key} = {pair.Value} {_comments[section.Key + pair.Key]}\n";
                    } else {
                        result += $"{pair.Key} = {pair.Value}\n";
                    }
                }
                if (_comments.ContainsKey(section.Key)) {
                    result += $"{_comments[section.Key]}\n";
                }
                result += '\n';
            }
            return result;
        }

        public void Print()
        {
            foreach (var section in _info) {
                Console.WriteLine($"[{section.Key}]");
                foreach (var pair in section.Value) {
                    if (_comments.ContainsKey(section.Key + pair.Key)) {
                        Console.WriteLine($"{pair.Key} = {pair.Value} {_comments[section.Key + pair.Key]}");
                    } else {
                        Console.WriteLine($"{pair.Key} = {pair.Value}");
                    }
                }
                if (_comments.ContainsKey(section.Key)) {
                    Console.WriteLine(_comments[section.Key]);
                }
                Console.WriteLine();
            }
        }
        public void Parse()
        {
            using (StreamReader reader = new StreamReader(_filePath)) {
                string[] lines = reader.ReadToEnd().Split('\n'); // Читаем весь файл и делим на строки
                string section = "";
                foreach (string sub in lines) { // Идём по строкам
                    if (sub.Contains("[")) {
                        section = StringPlus.GetBetween(sub, "[", "]"); // Выделяем название секции
                        _info[section] = new Dictionary<string, object>(); // Выделяем под название словарь
                    } else { // Если НЕТ кв. скобки
                        if (sub.Contains("=")) { // Если это ПАРА
                            if (sub.Contains(";")) { // Если есть комментарии
                                _comments.Add(section + sub.Split(" = ")[0], // Добавляем коммент в словарь
                                    StringPlus.MySubString(sub, sub.IndexOf(";"), sub.Length));
                                string subNoComments = StringPlus.MySubString(sub, 0, sub.IndexOf(";") - 1); // Выделяем строку без комментов
                                _info[section].Add(subNoComments.Split(" = ")[0], subNoComments.Split(" = ")[1]); // Добавляем ПАРУ
                            } else {
                                _info[section].Add(sub.Split(" = ")[0], sub.Split(" = ")[1]); // Добавляем пару без комментов
                            }
                        } else {
                            if (sub.Contains(";")) { // Если пустая строка с комментами то запоминаем её
                                if (_comments.ContainsKey(section)) {
                                    _comments[section] += ('\n' + sub);
                                } else {
                                    _comments.Add(section, '\n' + sub);
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}