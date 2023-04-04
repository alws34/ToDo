using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoYourTasks
{
    public class Attachment
    {
        public Attachment() { }

        public string FileName { get; set; }
        public string FilePath { get; set; }
        public string AttachmentID { get; set; }
        public string ParentTaskID { get; set; }
        public string ParentProjectID { get; set; }
        public string FileType { get; set; } //file extension
        public string AddedOn { get; set; }


        public string GetParentTaskID() { return ParentTaskID; }
        public string GetParentProjectID() { return ParentProjectID; }
        public string GetAttachmentID() { return AttachmentID; }
        public string GetFilePath() { return FilePath; }
        public string GetFileName() { return FileName; }
        public string GetAddedOn() { return AddedOn; }


        public void SetAddedOn(string addedOn) { AddedOn = addedOn; }
        public void SetParentTaskID(string parentTaskID) { ParentTaskID = parentTaskID; }
        public void SetAttachmentID(string attachmentID) { AttachmentID = attachmentID; }
        public void SetFilePath(string filePath) { FilePath = filePath; }
        public void SetFileName(string fileName) { FileName = fileName; }
        public void SetParentProjectID(string parentProjectID) { ParentProjectID = parentProjectID; }
    }
}
