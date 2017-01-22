from django.contrib.auth.decorators import login_required
from django.shortcuts import render, get_object_or_404
from django.utils import timezone
from .forms import PostForm
from .models import Post
from .models import Weather
from django.shortcuts import redirect


def post_copy(request, pk):
    post = get_object_or_404(Post, pk=pk)
    c_post = post.clone()
    Post.objects.create(author=c_post.author, title=c_post.title, text=c_post.text, created_date=c_post.created_date,
                        published_date=c_post.published_date)
    return render(request, 'blog/post_copy.html')

def get_weather(request):
    if(len(Weather.objects.all()) == 0):
        Weather.objects.create(time=timezone.now())

    weather = Weather.objects.all()
    weather[0].update_weather()
    return render(request, 'blog/weather.html', {'weather': weather})

def post_list(request):
    posts = Post.objects.filter(published_date__lte=timezone.now()).order_by('published_date')
    return render(request, 'blog/post_list.html', {'posts': posts})

def post_detail(request, pk):
    post = get_object_or_404(Post, pk=pk)
    return render(request, 'blog/post_detail.html', {'post': post})
#dekorator
@login_required
def post_new(request):
    if request.method == "POST":
        form = PostForm(request.POST)
        if form.is_valid():
            post = form.save(commit=False)
            post.author = request.user
            post.published_date = timezone.now()
            post.save()
            return redirect('post_detail', pk=post.pk)
    else:
        form = PostForm()
    return render(request, 'blog/post_edit.html', {'form': form})
#dekorator
@login_required
def post_edit(request, pk):
    post = get_object_or_404(Post, pk=pk)
    if request.method == "POST":
        form = PostForm(request.POST, instance=post)
        if form.is_valid():
            post = form.save(commit=False)
            post.author = request.user
            post.published_date = timezone.now()
            post.save()
            return redirect('post_detail', pk=post.pk)
    else:
        form = PostForm(instance=post)
    return render(request, 'blog/post_edit.html', {'form': form})