using BidOne.Data.Model;
using System;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;

namespace BidOne.Data
{
    public class Database : IDatabase
    {
        private readonly DataContractJsonSerializer userSerializer;

        public Database()
        {
            userSerializer = new DataContractJsonSerializer(typeof(UserDetailsData));
        }

        public async Task<UserDetailsData> CreateUser(UserDetailsData userDetailsData)
        {
            await Task.Factory.StartNew(() => {
                Guid userId = Guid.NewGuid();

                using (FileStream stream1 = new FileStream($"./Data/{userId.ToString()}.json", FileMode.CreateNew))
                {
                    userDetailsData.Id = userId;
                    userSerializer.WriteObject(stream1, userDetailsData);
                }

            });

            return userDetailsData;
        }
    }
}
