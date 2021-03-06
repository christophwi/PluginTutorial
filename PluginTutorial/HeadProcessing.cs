﻿using System.Linq;
using BaseLibS.Graph;
using BaseLibS.Param;
using PerseusApi.Document;
using PerseusApi.Generic;
using PerseusApi.Matrix;

namespace PluginTutorial
{
    public class HeadProcessing : IMatrixProcessing
    {
        public bool HasButton => false;
        public Bitmap2 DisplayImage => null;
        public string Description => "Extract the first few rows from the matrix.";
        public string HelpOutput => "Top of the input matrix.";
        public string[] HelpSupplTables => new string[0];
        public int NumSupplTables => 0;
        public string Name => "Head";
        public string Heading => "Filter rows";
        public bool IsActive => true;
        public float DisplayRank => 100;
        public string[] HelpDocuments => new string[0];
        public int NumDocuments => 0;

        public int GetMaxThreads(Parameters parameters)
        {
            return 1;
        }

        public string Url => "https://github.com/jdrudolph/PluginTutorial";

        public void ProcessData(IMatrixData mdata, Parameters param, ref IMatrixData[] supplTables,
            ref IDocumentData[] documents, ProcessInfo processInfo)
        {
            var numberOfRows = param.GetParam<int>("Number of rows").Value;
            var indices = Enumerable.Range(0, numberOfRows).ToArray();
            mdata.ExtractRows(indices);
        }

        public Parameters GetParameters(IMatrixData mdata, ref string errorString)
        {
            return new Parameters(new IntParam("Number of rows", 10));
        }
    }
}