using System.Reflection;

namespace PersonalDedupeTest;

public class ImageDedupUnitTest
{
    /// <summary>
    /// Tests that two known-different images get a likelihood of 1 for same extension.
    /// </summary>
    /// <param name="image1">Filename of first image to test.</param>
    /// <param name="image2">Filename of second image to test.</param>
    [Theory]
    [InlineData("HNI_0063.JPG", "HNI_0064.JPG")]
    public void KnownDifferentImagesAreExtensionEqual(string image1, string image2)
    {
        FileInfo fiImage1 = new FileInfo(image1);
        FileInfo fiImage2 = new FileInfo(image2);
        Assert.Equal(1, ImageDedup.ImagesLikelyDuplicate(fiImage1, fiImage2));
    }
    
    [Theory]
    [InlineData("HNI_0063.JPG", "HNI_DUP.JPG")]
    public void KnownDuplicateImagesAreLengthEqual(string image1, string image2)
    {
        FileInfo fiImage1 = new FileInfo(image1);
        FileInfo fiImage2 = new FileInfo(image2);
        Assert.Equal(2, ImageDedup.ImagesLikelyDuplicate(fiImage1, fiImage2));
    }
}