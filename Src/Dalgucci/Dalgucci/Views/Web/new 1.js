$(document).ready(function(){
	/*메뉴*/
	$(".nav>ul>a>li").mouseover(function() {
		$(this).children(".submenu").stop().slideDown();
	});
	$(".nav>ul>a>li").mouseleave(function() {
		$(this).children(".submenu").stop().slideUp();
	});
	
	/*이미지 마우스 오버
	$(".items > ul> li").mouseover(function() {
		$(this).children(".item_hover").stop().slideDown();
	});
	$(".items > ul> li").mouseleave(function() {
		$(this).children(".item_hover").stop().slideUp();
	});*/
	
});