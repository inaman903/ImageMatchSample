using CoenM.ImageHash.HashAlgorithms;
using CoenM.ImageHash;
using OpenCvSharp;
using SixLabors.ImageSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.ColorSpaces;
using System.Diagnostics;

namespace ImageMatchSample
{
    public static class ImageMatcher
    {
        public static double Hash(IImageHash hashArgorithm, Image<Rgba32> img1, Image<Rgba32> img2)
        {
            var hash1 = hashArgorithm.Hash(img1);
            var hash2 = hashArgorithm.Hash(img2);

            return CompareHash.Similarity(hash1, hash2);
        }

        public static double Hist(Mat mat1, Mat mat2)
        {
            using var hist1 = new Mat();
            using var hist2 = new Mat();

            Cv2.CalcHist(new Mat[] { mat1 }, new int[] { 0 }, null, hist1, 1, new int[] { 256 }, new Rangef[] { new Rangef(0, 256) });
            Cv2.CalcHist(new Mat[] { mat2 }, new int[] { 0 }, null, hist2, 1, new int[] { 256 }, new Rangef[] { new Rangef(0, 256) });

            return Cv2.CompareHist(hist1, hist2, HistCompMethods.Correl);
        }

        public static double Akaze(Mat mat1, Mat mat2)
        {
            using var descriptors1 = new Mat();
            using var descriptors2 = new Mat();

            var akaze = AKAZE.Create();
            akaze.DetectAndCompute(mat1, null, out KeyPoint[] keyPoints1, descriptors1);
            akaze.DetectAndCompute(mat2, null, out KeyPoint[] keyPoints2, descriptors2);

            var matcher = new BFMatcher(NormTypes.Hamming, false);
            var matches = matcher.Match(descriptors1, descriptors2);

            var sum = matches.Sum(x => x.Distance);
            return sum / matches.Length;
        }
    }
}
