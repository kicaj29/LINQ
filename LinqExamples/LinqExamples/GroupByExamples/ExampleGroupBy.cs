using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqExamples.GroupByExamples
{
    public class ExampleGroupBy
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

            var result = request.Documents.GroupBy(
                    d => new { d.ActionId, d.ActionType, d.Status, d.PrevActionId, d.PrevActionType, d.PrevStatus }
                );
        }
    }
}
