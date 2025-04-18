using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Assignment3.Tests
{
    public static class SerializationHelper
    {
        /// <summary>
        /// Serializes (encodes) users to a JSON file.
        /// </summary>
        /// <param name="users">List of users</param>
        /// <param name="fileName">File name to save the JSON data</param>
        public static void SerializeUsers(ILinkedListADT users, string fileName)
        {

            var userList = new List<User>();
            for (int i = 0; i < users.Count(); i++)
            {
                userList.Add(users.GetValue(i));
            }

            var json = JsonSerializer.Serialize(userList, new JsonSerializerOptions { WriteIndented = true });

            File.WriteAllText(fileName, json);
        }

        /// <summary>
        /// Deserializes (decodes) users from a JSON file.
        /// </summary>
        /// <param name="fileName">File name to read the JSON data</param>
        /// <returns>ILinkedListADT containing the deserialized users</returns>
        public static ILinkedListADT DeserializeUsers(string fileName)
        {

            var json = File.ReadAllText(fileName);

            var userList = JsonSerializer.Deserialize<List<User>>(json);

            var linkedList = new SLL();
            if (userList != null)
            {
                foreach (var user in userList)
                {
                    linkedList.AddLast(user);
                }
            }

            return linkedList;
        }
    }
}