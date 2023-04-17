﻿// This file was auto-generated by ML.NET Model Builder. 
using Microsoft.ML;
using Microsoft.ML.Data;
using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
namespace Selfdoctor_TrainingModels
{
    public partial class BreastCancerDiagnosticML
    {
        /// <summary>
        /// model input class for BreastCancerDiagnosticML.
        /// </summary>
        #region model input class
        public class ModelInput
        {
            [ColumnName(@"id")]
            public float Id { get; set; }

            [ColumnName(@"diagnosis")]
            public string Diagnosis { get; set; }

            [ColumnName(@"radius_mean")]
            public float Radius_mean { get; set; }

            [ColumnName(@"texture_mean")]
            public float Texture_mean { get; set; }

            [ColumnName(@"perimeter_mean")]
            public float Perimeter_mean { get; set; }

            [ColumnName(@"area_mean")]
            public float Area_mean { get; set; }

            [ColumnName(@"smoothness_mean")]
            public float Smoothness_mean { get; set; }

            [ColumnName(@"compactness_mean")]
            public float Compactness_mean { get; set; }

            [ColumnName(@"concavity_mean")]
            public float Concavity_mean { get; set; }

            [ColumnName(@"concave points_mean")]
            public float Concave_points_mean { get; set; }

            [ColumnName(@"symmetry_mean")]
            public float Symmetry_mean { get; set; }

            [ColumnName(@"fractal_dimension_mean")]
            public float Fractal_dimension_mean { get; set; }

            [ColumnName(@"radius_se")]
            public float Radius_se { get; set; }

            [ColumnName(@"texture_se")]
            public float Texture_se { get; set; }

            [ColumnName(@"perimeter_se")]
            public float Perimeter_se { get; set; }

            [ColumnName(@"area_se")]
            public float Area_se { get; set; }

            [ColumnName(@"smoothness_se")]
            public float Smoothness_se { get; set; }

            [ColumnName(@"compactness_se")]
            public float Compactness_se { get; set; }

            [ColumnName(@"concavity_se")]
            public float Concavity_se { get; set; }

            [ColumnName(@"concave points_se")]
            public float Concave_points_se { get; set; }

            [ColumnName(@"symmetry_se")]
            public float Symmetry_se { get; set; }

            [ColumnName(@"fractal_dimension_se")]
            public float Fractal_dimension_se { get; set; }

            [ColumnName(@"radius_worst")]
            public float Radius_worst { get; set; }

            [ColumnName(@"texture_worst")]
            public float Texture_worst { get; set; }

            [ColumnName(@"perimeter_worst")]
            public float Perimeter_worst { get; set; }

            [ColumnName(@"area_worst")]
            public float Area_worst { get; set; }

            [ColumnName(@"smoothness_worst")]
            public float Smoothness_worst { get; set; }

            [ColumnName(@"compactness_worst")]
            public float Compactness_worst { get; set; }

            [ColumnName(@"concavity_worst")]
            public float Concavity_worst { get; set; }

            [ColumnName(@"concave points_worst")]
            public float Concave_points_worst { get; set; }

            [ColumnName(@"symmetry_worst")]
            public float Symmetry_worst { get; set; }

            [ColumnName(@"fractal_dimension_worst")]
            public float Fractal_dimension_worst { get; set; }

        }

        #endregion

        /// <summary>
        /// model output class for BreastCancerDiagnosticML.
        /// </summary>
        #region model output class
        public class ModelOutput
        {
            [ColumnName(@"id")]
            public float Id { get; set; }

            [ColumnName(@"diagnosis")]
            public uint Diagnosis { get; set; }

            [ColumnName(@"radius_mean")]
            public float Radius_mean { get; set; }

            [ColumnName(@"texture_mean")]
            public float Texture_mean { get; set; }

            [ColumnName(@"perimeter_mean")]
            public float Perimeter_mean { get; set; }

            [ColumnName(@"area_mean")]
            public float Area_mean { get; set; }

            [ColumnName(@"smoothness_mean")]
            public float Smoothness_mean { get; set; }

            [ColumnName(@"compactness_mean")]
            public float Compactness_mean { get; set; }

            [ColumnName(@"concavity_mean")]
            public float Concavity_mean { get; set; }

            [ColumnName(@"concave points_mean")]
            public float Concave_points_mean { get; set; }

            [ColumnName(@"symmetry_mean")]
            public float Symmetry_mean { get; set; }

            [ColumnName(@"fractal_dimension_mean")]
            public float Fractal_dimension_mean { get; set; }

            [ColumnName(@"radius_se")]
            public float Radius_se { get; set; }

            [ColumnName(@"texture_se")]
            public float Texture_se { get; set; }

            [ColumnName(@"perimeter_se")]
            public float Perimeter_se { get; set; }

            [ColumnName(@"area_se")]
            public float Area_se { get; set; }

            [ColumnName(@"smoothness_se")]
            public float Smoothness_se { get; set; }

            [ColumnName(@"compactness_se")]
            public float Compactness_se { get; set; }

            [ColumnName(@"concavity_se")]
            public float Concavity_se { get; set; }

            [ColumnName(@"concave points_se")]
            public float Concave_points_se { get; set; }

            [ColumnName(@"symmetry_se")]
            public float Symmetry_se { get; set; }

            [ColumnName(@"fractal_dimension_se")]
            public float Fractal_dimension_se { get; set; }

            [ColumnName(@"radius_worst")]
            public float Radius_worst { get; set; }

            [ColumnName(@"texture_worst")]
            public float Texture_worst { get; set; }

            [ColumnName(@"perimeter_worst")]
            public float Perimeter_worst { get; set; }

            [ColumnName(@"area_worst")]
            public float Area_worst { get; set; }

            [ColumnName(@"smoothness_worst")]
            public float Smoothness_worst { get; set; }

            [ColumnName(@"compactness_worst")]
            public float Compactness_worst { get; set; }

            [ColumnName(@"concavity_worst")]
            public float Concavity_worst { get; set; }

            [ColumnName(@"concave points_worst")]
            public float Concave_points_worst { get; set; }

            [ColumnName(@"symmetry_worst")]
            public float Symmetry_worst { get; set; }

            [ColumnName(@"fractal_dimension_worst")]
            public float Fractal_dimension_worst { get; set; }

            [ColumnName(@"Features")]
            public float[] Features { get; set; }

            [ColumnName(@"PredictedLabel")]
            public string PredictedLabel { get; set; }

            [ColumnName(@"Score")]
            public float[] Score { get; set; }

        }

        #endregion

        private static string MLNetModelPath = Path.GetFullPath("BreastCancerDiagnosticML.zip");

        public static readonly Lazy<PredictionEngine<ModelInput, ModelOutput>> PredictEngine = new Lazy<PredictionEngine<ModelInput, ModelOutput>>(() => CreatePredictEngine(), true);

        /// <summary>
        /// Use this method to predict on <see cref="ModelInput"/>.
        /// </summary>
        /// <param name="input">model input.</param>
        /// <returns><seealso cref=" ModelOutput"/></returns>
        public static ModelOutput Predict(ModelInput input)
        {
            var predEngine = PredictEngine.Value;
            return predEngine.Predict(input);
        }

        private static PredictionEngine<ModelInput, ModelOutput> CreatePredictEngine()
        {
            var mlContext = new MLContext();
            ITransformer mlModel = mlContext.Model.Load(MLNetModelPath, out var _);
            return mlContext.Model.CreatePredictionEngine<ModelInput, ModelOutput>(mlModel);
        }
    }
}
