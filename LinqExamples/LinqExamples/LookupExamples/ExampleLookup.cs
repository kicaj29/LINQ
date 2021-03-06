using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqExamples.LookupExamples
{
    public class ExampleLookup
    {
        public static void Run()
        {
            BatchStateChangeRequest request = new BatchStateChangeRequest();

            request.Documents = new List<BatchStateChangeDocument>();

            request.Documents.Add(new BatchStateChangeDocument()
            {
                Id = "1",
                ActionId = "OCR-111",
                ActionType = "OCR",
                Status = "Queued",
                PrevActionId = null,
                PrevActionType = null,
                PrevStatus = null
            });

            request.Documents.Add(new BatchStateChangeDocument()
            {
                Id = "2",
                ActionId = "OCR-111",
                ActionType = "OCR",
                Status = "Queued",
                PrevActionId = null,
                PrevActionType = null,
                PrevStatus = null
            });

            request.Documents.Add(new BatchStateChangeDocument()
            {
                Id = "3",
                ActionId = "VER-111",
                ActionType = "VER",
                Status = "Queued",
                PrevActionId = null,
                PrevActionType = null,
                PrevStatus = null
            });

            // to group correctly using explicit type this type has to implement GetHashCode and Equals
            ILookup<UpdateCommand, string> lookupResult = request.Documents.ToLookup<BatchStateChangeDocument, UpdateCommand, string>(d => new UpdateCommand
            {
                ActionId = d.ActionId,
                ActionType = d.ActionType,
                Status =  d.Status,
                PrevActionId = d.PrevActionId,
                PrevActionType = d.PrevActionType,
                PrevStatus = d.PrevStatus
            }, d => d.Id);

            var lookupResultAnonymousType = request.Documents.ToLookup(d => new
            {
                d.ActionId,
                d.ActionType,
                d.Status,
                d.PrevActionId,
                d.PrevActionType,
                d.PrevStatus
            }, d => d.Id);

            int index = 0;
            foreach(IGrouping<UpdateCommand, string> item in lookupResult)
            {
                Console.WriteLine($"---Command{index}---");
                UpdateCommand command = item.Key;
                command.Ids = new List<string>();
                foreach (string id in item)
                {
                    Console.WriteLine(id);
                    command.Ids.Add(id);
                }
                index++;
            }

            index = 0;
            foreach (var item in lookupResultAnonymousType)
            {
                Console.WriteLine($"---Command{index}---");
                foreach (var id in item)
                {
                    Console.WriteLine(id);
                }
                index++;
            }
        }
    }
}
