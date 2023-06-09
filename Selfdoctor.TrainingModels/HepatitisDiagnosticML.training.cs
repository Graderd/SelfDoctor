﻿﻿// This file was auto-generated by ML.NET Model Builder. 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ML.Data;
using Microsoft.ML.Trainers.FastTree;
using Microsoft.ML.Trainers;
using Microsoft.ML.Transforms;
using Microsoft.ML;

namespace Selfdoctor_TrainingModels
{
    public partial class HepatitisDiagnosticML
    {
        /// <summary>
        /// Retrains model using the pipeline generated as part of the training process. For more information on how to load data, see aka.ms/loaddata.
        /// </summary>
        /// <param name="mlContext"></param>
        /// <param name="trainData"></param>
        /// <returns></returns>
        public static ITransformer RetrainPipeline(MLContext mlContext, IDataView trainData)
        {
            var pipeline = BuildPipeline(mlContext);
            var model = pipeline.Fit(trainData);

            return model;
        }

        /// <summary>
        /// build the pipeline that is used from model builder. Use this function to retrain model.
        /// </summary>
        /// <param name="mlContext"></param>
        /// <returns></returns>
        public static IEstimator<ITransformer> BuildPipeline(MLContext mlContext)
        {
            // Data process configuration with pipeline data transformations
            var pipeline = mlContext.Transforms.Categorical.OneHotEncoding(@"Sex", @"Sex", outputKind: OneHotEncodingEstimator.OutputKind.Indicator)      
                                    .Append(mlContext.Transforms.ReplaceMissingValues(new []{new InputOutputColumnPair(@"Age", @"Age"),new InputOutputColumnPair(@"ALB", @"ALB"),new InputOutputColumnPair(@"ALP", @"ALP"),new InputOutputColumnPair(@"AST", @"AST"),new InputOutputColumnPair(@"BIL", @"BIL"),new InputOutputColumnPair(@"CHE", @"CHE"),new InputOutputColumnPair(@"CHOL", @"CHOL"),new InputOutputColumnPair(@"CREA", @"CREA"),new InputOutputColumnPair(@"GGT", @"GGT"),new InputOutputColumnPair(@"PROT", @"PROT")}))      
                                    .Append(mlContext.Transforms.Text.FeaturizeText(inputColumnName:@"ALT",outputColumnName:@"ALT"))      
                                    .Append(mlContext.Transforms.Concatenate(@"Features", new []{@"Sex",@"Age",@"ALB",@"ALP",@"AST",@"BIL",@"CHE",@"CHOL",@"CREA",@"GGT",@"PROT",@"ALT"}))      
                                    .Append(mlContext.Transforms.Conversion.MapValueToKey(outputColumnName:@"Category",inputColumnName:@"Category"))      
                                    .Append(mlContext.MulticlassClassification.Trainers.OneVersusAll(binaryEstimator:mlContext.BinaryClassification.Trainers.FastForest(new FastForestBinaryTrainer.Options(){NumberOfTrees=48,NumberOfLeaves=4,FeatureFraction=1F,LabelColumnName=@"Category",FeatureColumnName=@"Features"}),labelColumnName:@"Category"))      
                                    .Append(mlContext.Transforms.Conversion.MapKeyToValue(outputColumnName:@"PredictedLabel",inputColumnName:@"PredictedLabel"));

            return pipeline;
        }
    }
}
