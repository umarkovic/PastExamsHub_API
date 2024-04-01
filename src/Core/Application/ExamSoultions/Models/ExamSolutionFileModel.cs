using BitMiracle.LibTiff.Classic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastExamsHub.Core.Application.ExamSoultions.Models
{
    public class ExamSolutionFileModel : ExamSolutionModel
    {
        public byte[] File { get; set; }
        public string ContentType { get; set; }
    }
}
