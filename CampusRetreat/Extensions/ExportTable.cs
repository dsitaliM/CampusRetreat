using System.Collections.Generic;
using System.IO;
using CampusRetreat.Models;
using CampusRetreat.Repository;
using CsvHelper;

namespace CampusRetreat.Extensions
{
    public static class ExportTable
    {
//        private readonly IGuestRepository _guestsGuestRepository;
//
//        public ExportTable(IGuestRepository guestRepository)
//        {
//            _guestsGuestRepository = guestRepository;
//        }
        
        public static byte[] WriteCsvToMemory(IEnumerable<Guest> guests)
        {
            using (var memoryStream = new MemoryStream())
            using (var streamWriter = new StreamWriter(memoryStream))
            using (var csvWriter = new CsvWriter(streamWriter))
            {
                csvWriter.WriteRecords(guests);
                streamWriter.Flush();
                return memoryStream.ToArray();
            }
        }
    }
}