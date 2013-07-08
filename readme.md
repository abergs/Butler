#Butler - ~~World~~ Developer Class CMS
Butler won't get in your way. Build your site as you want to, then add Butler as a drop-in Backend for your models.

*Word of warning; Butler is in Alpha2, fully working, but primitive. Works on my machine guarantee issued :)*

## What is Butler?
Butler is a pluginnable backend for your MVC4 site. After installing the Nuget Package, an area will be added at `yourapp.com/Butler/` where you and your users can login, and create/edit/store models for your application. You can then retrieve the model and present it as you wish inside your views.

## No bullshit
Butler won't get in your way. Create your site, then add Butler to enable content editing. You don't have to create templates or setup page structures. 

## Get started
Get up and running in 5 minutes.

#### Install Butler Nuget Package
`Install-Package Butler`

#### Edit Global.asax
Edit your global.asax to enable Butlers routes to work.
`ControllerBuilder.Current.SetControllerFactory(new ButlerWeb.Areas.Butler.Controllers.ControllerFactory());`

#### Create a Model
Now, just create a Model that can store the information you want.
Here is an example:

	namespace MyMvcApplication.Models {
		public class MyEditablePageInfo : ButlerCore.ButlerDocument {
			public string Title { get; set; }
			public string Summary { get; set; }
			public string Content { get; set; }
			public string AnyOtherText { get; set; }
		}
	}
	
Butler works with the models in your application, it will look for them in `YourApplication.Models`, this is everything you need to do in order to have the backend allow you to create and store that model.
#### Create content
Start your application, Head over to `/Butler`. Create a new MyEditablePageInfo. Butler will force you to enter an ID for this perticular `MyEditablePageInfo`. This ID will be used when fetching the data for presentation later.

#### Fetch your Model in your Controller/view
Now when you have stored data, you need to retrieve it in order to show it. This can be done in your controller (it can be done everywhere).
	
	var info = ButlerCore.Store.Get<MyMvcApplication.Models.MyEditablePageInfo>("TheIDYouSpecifiedEarlier");
	ViewBag.MyInfo = info;
	ViewBag.Title = info.Name;
	
#### Done!

Contact me (@bigCheeseAnders) if you have any questions, feedback or anything else to discuss. I'd be happy to help you!
Have a great day.

