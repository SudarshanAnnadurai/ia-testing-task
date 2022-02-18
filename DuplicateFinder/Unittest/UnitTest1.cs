using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using DuplicateFinder.Logic;
using DuplicateFinder.Logic.Model;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Unittest
{
    [TestClass]
    public class UnitTest1

    {
        [TestMethod]
        public void sameSize()
        {
            string folder = @"..\..\..\testFolder\sameSize";
            var testPath = Path.GetFullPath(folder);
            var resultFile = File.ReadAllLines(Path.Combine(testPath, "ResultSameSize.txt"));
            var fileList = new List<string>(resultFile);
            List<List<String>> testList = new List<List<String>>();
            for (int i = 0; i < fileList.Count; i++)
            {
                var absfileList = Path.Combine(testPath, fileList[i]);
                fileList[i] = fileList[i].Replace(fileList[i], absfileList);
            }
            DuplicateFinder.Logic.DuplicateFinder dupFind = new DuplicateFinder.Logic.DuplicateFinder();
            var dupOuput = dupFind.CollectCandidates(testPath, CompareMode.Size).ToList();
            foreach (var duplicate1 in dupOuput)
            {
                var outputPaths = duplicate1.FilePaths.ToList();
                bool a = outputPaths.All(fileList.Contains);
                Assert.IsTrue(a);
                Console.WriteLine("SameSize validation passed");
            }
            
        }

        [TestMethod]
        public void sameSizeandName()
        {
            string folder = @"..\..\..\testFolder\sameSizeName";
            var testPath = Path.GetFullPath(folder);
            var resultFile = File.ReadAllLines(Path.Combine(testPath, "ResultSameSizeName.txt"));
            Console.WriteLine(resultFile);
            var fileList = new List<string>(resultFile);
            List<List<String>> testList = new List<List<String>>();
            for (int i = 0; i < fileList.Count; i++)
            {
                var absfileList = Path.Combine(testPath, fileList[i]);
                fileList[i] = fileList[i].Replace(fileList[i], absfileList);
            }
            foreach (var file in fileList) { Console.WriteLine(file); }
            DuplicateFinder.Logic.DuplicateFinder dupFind = new DuplicateFinder.Logic.DuplicateFinder();
            var dupOuput = dupFind.CollectCandidates(testPath, CompareMode.SizeAndName).ToList();
            foreach (var duplicate1 in dupOuput)
            {
                var outputPaths = duplicate1.FilePaths.ToList();
                foreach (var outputPath in outputPaths) { Console.WriteLine(outputPath); }
                bool a = outputPaths.All(fileList.Contains);
                Assert.IsTrue(a);
                Console.WriteLine("SameSizeAndName validation passed");
            }

        }
        [TestMethod]
        public void md5Hash()
        {
            string folder = @"..\..\..\testFolder\sameSizeName";
            var testPath = Path.GetFullPath(folder);
            var resultFile = File.ReadAllLines(Path.Combine(testPath, "ResultSameSizeName.txt"));
            Console.WriteLine(resultFile);
            var fileList = new List<string>(resultFile);
            List<List<String>> testList = new List<List<String>>();
            for (int i = 0; i < fileList.Count; i++)
            {
                var absfileList = Path.Combine(testPath, fileList[i]);
                fileList[i] = fileList[i].Replace(fileList[i], absfileList);
            }
            foreach (var file in fileList) { Console.WriteLine(file); }
            DuplicateFinder.Logic.DuplicateFinder dupFind = new DuplicateFinder.Logic.DuplicateFinder();
            var collectOutput = dupFind.CollectCandidates(testPath, CompareMode.SizeAndName).ToList();
            var dupOuput =dupFind.CheckCandidates(collectOutput).ToList(); 
            foreach (var duplicate1 in dupOuput)
            {
                var outputPaths = duplicate1.FilePaths.ToList();
                foreach (var outputPath in outputPaths) { Console.WriteLine(outputPath); }
                bool a = outputPaths.All(fileList.Contains);
                Assert.IsTrue(a);
                Console.WriteLine("md5Hash validation passed");
            }

        }
    }

}