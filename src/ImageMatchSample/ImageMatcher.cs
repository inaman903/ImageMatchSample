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

            // サイズが小さいと特徴点が取れない場合がある
            using var m1 = new Mat();
            Cv2.Resize(mat1, m1, new OpenCvSharp.Size(600, 600));
            using var m2 = new Mat();
            Cv2.Resize(mat2, m2, new OpenCvSharp.Size(600, 600));

            var akaze = AKAZE.Create();
            akaze.DetectAndCompute(m1, null, out KeyPoint[] keyPoints1, descriptors1);
            akaze.DetectAndCompute(m2, null, out KeyPoint[] keyPoints2, descriptors2);

            if (!descriptors1.Empty() && !descriptors2.Empty())
            {
                // crossCheckをtrueにする精度が上がる気がするが
                // 特徴点が見つかっていないと例外
                var matcher = new BFMatcher(NormTypes.Hamming, true);
                var matches = matcher.Match(descriptors1, descriptors2);

                var sum = matches.Sum(x => x.Distance);
                return sum / matches.Length;
            }
            return double.NaN;
        }
    }
}
