using CoenM.ImageHash.HashAlgorithms;
using ImageMatchSample;
using OpenCvSharp;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

// 円
using var matCircle = new Mat(@"circle.png");
using var imgCircle = Image.Load<Rgba32>(@"circle.png");

// 楕円
using var matOval = new Mat(@"oval.png");
using var imgOval = Image.Load<Rgba32>(@"oval.png");

// 円2x
using var matCircle2x = new Mat(@"circle2x.png");
using var imgCircle2x = Image.Load<Rgba32>(@"circle2x.png");

// 円0.5x
using var matCircle05x = new Mat(@"circle05x.png");
using var imgCircle05x = Image.Load<Rgba32>(@"circle05x.png");

// 円赤
using var matCircleRed = new Mat(@"circle_red.png");
using var imgCircleRed = Image.Load<Rgba32>(@"circle_red.png");

// 円余白
using var matCircleMargin = new Mat(@"circle_margin.png");
using var imgCircleMargin = Image.Load<Rgba32>(@"circle_margin.png");


// AKAZE
Console.WriteLine("AKAZE");
Console.WriteLine("Circle <-> Circle:" + ImageMatcher.Akaze(matCircle, matCircle));
Console.WriteLine("Circle <-> Oval:" + ImageMatcher.Akaze(matCircle, matOval));
Console.WriteLine("Circle <-> Circle2x:" + ImageMatcher.Akaze(matCircle, matCircle2x));
Console.WriteLine("Circle <-> Circle0.5x:" + ImageMatcher.Akaze(matCircle, matCircle05x));
Console.WriteLine("Circle <-> CircleRed:" + ImageMatcher.Akaze(matCircle, matCircleRed));
Console.WriteLine("Circle <-> CircleMargin:" + ImageMatcher.Akaze(matCircle, matCircleMargin));

// Hist
Console.WriteLine("Hist");
Console.WriteLine("Circle <-> Circle:" + ImageMatcher.Hist(matCircle, matCircle));
Console.WriteLine("Circle <-> Oval:" + ImageMatcher.Hist(matCircle, matOval));
Console.WriteLine("Circle <-> Circle2x:" + ImageMatcher.Hist(matCircle, matCircle2x));
Console.WriteLine("Circle <-> Circle0.5x:" + ImageMatcher.Hist(matCircle, matCircle05x));
Console.WriteLine("Circle <-> CircleRed:" + ImageMatcher.Hist(matCircle, matCircleRed));
Console.WriteLine("Circle <-> CircleMargin:" + ImageMatcher.Hist(matCircle, matCircleMargin));

// PHash
Console.WriteLine("PHash");
Console.WriteLine("Circle <-> Circle:" + ImageMatcher.Hash(new PerceptualHash(), imgCircle, imgCircle));
Console.WriteLine("Circle <-> Oval:" + ImageMatcher.Hash(new PerceptualHash(), imgCircle, imgOval));
Console.WriteLine("Circle <-> Circle2x:" + ImageMatcher.Hash(new PerceptualHash(), imgCircle, imgCircle2x));
Console.WriteLine("Circle <-> Circle0.5x:" + ImageMatcher.Hash(new PerceptualHash(), imgCircle, imgCircle05x));
Console.WriteLine("Circle <-> CircleRed:" + ImageMatcher.Hash(new PerceptualHash(), imgCircle, imgCircleRed));
Console.WriteLine("Circle <-> CircleMargin:" + ImageMatcher.Hash(new PerceptualHash(), imgCircle, imgCircleMargin));

// AHash
Console.WriteLine("AHash");
Console.WriteLine("Circle <-> Circle:" + ImageMatcher.Hash(new AverageHash(), imgCircle, imgCircle));
Console.WriteLine("Circle <-> Oval:" + ImageMatcher.Hash(new AverageHash(), imgCircle, imgOval));
Console.WriteLine("Circle <-> Circle2x:" + ImageMatcher.Hash(new AverageHash(), imgCircle, imgCircle2x));
Console.WriteLine("Circle <-> Circle0.5x:" + ImageMatcher.Hash(new AverageHash(), imgCircle, imgCircle05x));
Console.WriteLine("Circle <-> CircleRed:" + ImageMatcher.Hash(new AverageHash(), imgCircle, imgCircleRed));
Console.WriteLine("Circle <-> CircleMargin:" + ImageMatcher.Hash(new AverageHash(), imgCircle, imgCircleMargin));

// DHash
Console.WriteLine("DHash");
Console.WriteLine("Circle <-> Circle:" + ImageMatcher.Hash(new DifferenceHash(), imgCircle, imgCircle));
Console.WriteLine("Circle <-> Oval:" + ImageMatcher.Hash(new DifferenceHash(), imgCircle, imgOval));
Console.WriteLine("Circle <-> Circle2x:" + ImageMatcher.Hash(new DifferenceHash(), imgCircle, imgCircle2x));
Console.WriteLine("Circle <-> Circle0.5x:" + ImageMatcher.Hash(new DifferenceHash(), imgCircle, imgCircle05x));
Console.WriteLine("Circle <-> CircleRed:" + ImageMatcher.Hash(new DifferenceHash(), imgCircle, imgCircleRed));
Console.WriteLine("Circle <-> CircleMargin:" + ImageMatcher.Hash(new DifferenceHash(), imgCircle, imgCircleMargin));