## 기본 구조
### Program.cs 와 Startup.cs

 - Main : BuildWebHost 를 들고와서 실행 시키는 역할
 - BuildWebHost : `WebHost` 클래스의 `CreateDefaultBuilder`함수를 부르는데 여기에 우리 앱의 기초 환경설정이나 로깅, 
 기본 서버 셋팅 등 웹 어플리케이션을 실행시키기 위한 기본적인 것들을 구축함.
 여기서 `UseStartup` 은 웹 요청이 우리 서버에 들어왔을때 어떤 클래스를 써야하는(Startup) 지 알려주고 있다.
 `Startup` 클래스는 우리 어플리케이션의 엔진과 같은 역할을 한다.
 `ConfigureServices` 는 하나의 파라미터 `IServiceCollection` 을 받고 있는데 이 녀석은 컨테이너라는 녀석이다. 이 컨테이너에다가 서비스를 추가하면 
 **의존성 주입**으로 사용할 수 있다.
 `Configure` 는 HTTP 프로세싱 파이프라인을 설정하는 곳. 쉽게 말해서 어떤 웹 요청이 왔을 떄 어떤 식으로 진행할 것인지 정의하는 곳.

 ### wwwroot
 웹서버의 루트가 되는 곳. html, css, image 등 정적인 파일들이 들어간다. C#, Razor 와 같은 파일은 이 폴더 밖에 위치해야한다.
 Startup.cs 의 Configure 함수에 app.UseStaticFiles() 를 추가해야 wwwroot 안에 있는 파일들을 인지한다.

-----

 ## MVC
 닷넷 코어에서는 MVC 프레임워크를 선택해서 어플리케이션을 만들 수 있는데 MVC가 무엇인지 알아보자.

 Model - View - Controller (서로 협력하는 관계)
  - Model : 데이터를 다루는 것을 나타냄
  - View : 사용자들에게 실질적으로 보여주는 부분을 말한다
  - Controller : 로직을 담당

 Web 요청을 들어오면 컨트롤러 클래스로 가고 컨트롤러 안에서 모델을 통해 데이터를 가져오는데 이떄 모델을 DB랑 소통하고 있다.

 받은 데이터는 컨트롤러 안에서 로직을 통해 변경이 되고 그것을 뷰로 보낸다.

 뷰에서는 받은 데이터를 가지고 사용자들에게 렌더링하여 보여주며 사용자들이 뷰에서
 업데이트같은 행동을 했을 때 컨트롤러로 보내게 된다.


## 컨트롤러와 뷰
컨트롤러를 만들 때 뒤에 Controller 라는 접미사를 꼭 붙여야한다.
`IActionResult` 는 함수 안에 짜놓은 코드들을 알맞게 뷰에 맵핑하여 리턴을 해주게 되는데 뷰를 리턴할 떄 asp.net core mvc 룰에 따라야 한다.
Views 를 만들때 해당 컨트롤러의 이름과 같은(뒤에 Controller 제외) 폴더를 만들고 `IActionResult` 함수의 이름과 같은 Razor 파일을 만든다.

------

## Razor

웹 사이트에서 어느 페이지에 가도 동일하게 보이는 것이 있다. 네비게이션 바 혹은 푸터 등, 이 들을 보여주기 위해 페이지를 만들때 마다 추가시키는 것은 번거롭다..  그래서 Layout 이라는 마스터 뷰를 만들어 거기에 네비게이션 바와 푸터를 추가하여
어느 페이지를 가도 보이게 설정을 할 수 있다.

Views 폴더에 Shared 라는 폴더를 만든다. Shared 는 MVC 프레임워크에서 이 폴더안에 잇는 레이저 파일을 이 어플리케이션 어디서나 쓸 수 있게 설정되어 있다

`@RenderBody()` : 레이아웃 뷰에 꼭 있어야되는 코드이다. 이 위치에 다른 컨텐츠들을 보여주기위한 곳이다.

`<li><a asp-controller="Home" asp-action="Student">Student</a></li>`

Student 텝을 클릭했을때 Home 컨트롤러에 Student 엑션을 사용하겠다 

`ViewBag` 는 dynamic 타입

뷰 파일을 렌더링하기 이전에 항상 먼저 하는게 있는데 `_ViewStart`라는 파일이 있는지 없는지 확인하여 있으면 그 안에 있는 코드를 먼저 실행한다

=> 각각의 뷰 파일마다 `/Shared/_Layout.cshtml` 을 사용하겠다고 명시하는거는 번거럽다 그래서 대신에 `_ViewStart` 파일에 이 설정을 넣어주면 다른 뷰에 넣지 않아도 된다.

런타임떄 Razor 엔진이 뷰 파일을 컴파일하기 이전에 뷰 파일에 있는 html 코드나 C#코드, 태그 헬퍼가 올바르게 작동하는지 한번 쭈욱 본다.

Student 뷰에서 `StudentTeacherViewModel` 를 사용하기 위해 `@model StudentTeacherViewModel` 라고 명시를 했는데 이 클래스는 namespace를 
추가함으로써 알려주어야한다. 매번 뷰를 추가할때마다 추가해야하는 번거러움이 있다 -> `_ViewImports` 에 추가를 하여 매번 추가안해도 된다 

### Partial 뷰
- Partial 뷰 :  재사용이 필요한 부분을 따로 분리시켜서 만든 것이 Partail 뷰이다

`Home/_TeacherTable.cshtml` 을 보면 _ 이 보이는데 이것은 이 뷰를 Partail 뷰로 쓰겠다는 암묵적인 의미이다 

Index 뷰 또는 Student 뷰에 `_TeahcerTable` Partial 뷰를 사용하겠다라고 코드를 밑의 코드와 같이 추가한다

`@await Html.PartialAsync("_TeacherTable", Model);`

async 와 await 키워드를 사용하엿는데 이 둘을 사용하면 혹시 모를 데드락을 예방할 수 있는 예방책이라고 생각하면 될 거 같다. 
 - 첫번째 파라미터 : 내가 쓸 partial 뷰 이름
 - 두번째 파라미터 : 모델을 넘긴다 (없어도 됨 -> 단순 html만 쓰는거라면 상관없음)

Index 뷰를 보면 `StudentTeacherViewModel를 @await Html.PartialAsync("_TeacherTable", Model);` 에서 Model로 넘겨
`_TeacherTable` partail 뷰가 받아 foreach문으로 보여주고 있다.

정리하자면 여러페이지에서 똑같이 쓰이는 부분이 있다면 그 부분을 따로 띄어내서 partial 뷰로 만들어 사용하여 유지보수면에서 효율적인 코드가 될 수 있다.
