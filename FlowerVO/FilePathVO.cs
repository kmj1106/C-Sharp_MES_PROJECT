using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerVO
{
    public class FilePathVO
    {
        public string FileName { get; set; } //파일명
        public string Path { get; set; } //전체경로
        public long Length { get; set; } //파일크기
        public bool IsSuccess { get; set; }
    }
}
