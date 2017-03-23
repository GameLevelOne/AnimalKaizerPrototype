using System;
using UnityEngine.EventSystems;

namespace UnityEngine.UI.Extensions{

	[RequireComponent(typeof(ScrollRect))]
	[AddComponentMenu("UI/Extensions/Horizontal Scroll Snap")]
	public class HorizontalScrollSnap : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler{
		Transform _screensContainer;

		int _screens = 1;
		int _startingScreen = 1;

		bool _fastSwipeTimer = false;
		int _fastSwipeCounter = 0;
		int fastSwipeTarget = 30;

		System.Collections.Generic.List<Vector3> _positions;
		ScrollRect _scroll_rect;
		private Vector3 _lerp_target;
		bool _lerp;

		int _containerSize;

		[TooltipAttribute("The gameobject that contains toggles which siggest pagination. (optional")]
		public GameObject Pagination;

		[TooltipAttribute("Button to go to the next page. (optional")]
		public GameObject NextButton;

		[TooltipAttribute("Button to go to the previous page. (optional")]
		public GameObject PrevButton;

		public Boolean UseFasSwipe = true;
		public int FastSwipeThreshold = 100;

		bool _startDrag = true;
		Vector3 _startPosition = new Vector3();
		int _currentScreen;

		void Start(){
			
		}

		void Update(){}
	}

}