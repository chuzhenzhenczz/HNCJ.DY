
//files侧边栏实现
var YTMenu = (function() {

	function init() {
		
		[].slice.call( document.querySelectorAll( '.dr-menu' ) ).forEach( function( el, i ) {

			var trigger = el.querySelector( 'div.dr-trigger' ),
				icon = trigger.querySelector( 'span.dr-icon-menu' ),
				open = false;

			trigger.addEventListener( 'click', function( event ) {
				if( !open ) {
					el.className += ' dr-menu-open';
					open = true;
				}
			}, false );

			icon.addEventListener( 'click', function( event ) {
				if( open ) {
					event.stopPropagation();
					open = false;
					el.className = el.className.replace(/\bdr-menu-open\b/,'');
					return false;
				}
			}, false );

		} );

	}

	init();

})();