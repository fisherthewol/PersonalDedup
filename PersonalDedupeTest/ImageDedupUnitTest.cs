using System.Reflection;

namespace PersonalDedupeTest;

public class ImageDedupUnitTest
{
    /// <summary>
    /// Tests that two known-different images are marked as non-duplicate.
    /// </summary>
    /// <param name="image1">Filename of first image to test.</param>
    /// <param name="image2">Filename of second image to test.</param>
    [Theory]
    [InlineData("HNI_0063.JPG", "HNI_0064.JPG")]
    public void KnownDifferentImagesArentDuplicate(string image1, string image2)
    {
        FileInfo fiImage1 = new FileInfo(image1);
        FileInfo fiImage2 = new FileInfo(image2);
        Assert.Equal(0, ImageDedup.ImagesLikelyDuplicate(fiImage1, fiImage2));
    }
}