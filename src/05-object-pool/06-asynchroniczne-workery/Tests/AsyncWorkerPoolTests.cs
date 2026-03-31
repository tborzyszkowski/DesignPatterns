using AsyncWorkersSample;
using Xunit;

namespace AsyncWorkersSample.Tests;

public class AsyncWorkerPoolTests
{
    [Fact]
    public async Task AcquireWorkerAsync_ReturnsWorker()
    {
        var pool = new AsyncWorkerPool(maxPoolSize: 1);

        var result = await pool.AcquireWorkerAsync(TimeSpan.FromSeconds(2));

        Assert.NotNull(result);
        Assert.Equal(1, result!.Value.Worker.WorkerId);
    }

    [Fact]
    public async Task AcquireWorkerAsync_Timeout_ReturnsNull()
    {
        var pool = new AsyncWorkerPool(maxPoolSize: 1);

        var first = await pool.AcquireWorkerAsync(TimeSpan.FromSeconds(2));

        var second = await pool.AcquireWorkerAsync(TimeSpan.FromMilliseconds(50));

        Assert.Null(second);

        pool.ReleaseWorker(first!.Value.Worker);
    }

    [Fact]
    public async Task ReleaseWorker_AllowsNextAcquire()
    {
        var pool = new AsyncWorkerPool(maxPoolSize: 1);

        var first = await pool.AcquireWorkerAsync(TimeSpan.FromSeconds(2));
        pool.ReleaseWorker(first!.Value.Worker);

        var second = await pool.AcquireWorkerAsync(TimeSpan.FromSeconds(2));

        Assert.NotNull(second);
        Assert.Equal(first.Value.Worker.WorkerId, second!.Value.Worker.WorkerId);
    }

    [Fact]
    public async Task HeavyWorker_ProcessJobAsync_Completes()
    {
        var worker = new HeavyWorker(99);

        await worker.ProcessJobAsync(1);
    }

    [Fact]
    public void AcquireResult_StoresValues()
    {
        var worker = new HeavyWorker(1);
        var result = new AcquireResult(worker, 50);

        Assert.Equal(1, result.Worker.WorkerId);
        Assert.Equal(50, result.WaitMs);
    }
}
