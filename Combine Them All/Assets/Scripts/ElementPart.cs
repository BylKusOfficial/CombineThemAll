using HighlightPlus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementPart : MonoBehaviour
{
	[SerializeField] private bool isFixed = false;
	public DragObject dragObject { get; private set; }

	private Renderer renderer;
	private Material originalMaterial;
	private HighlightEffect highlightEffect;

	private void Awake()
	{
		if(!isFixed)
		{
			dragObject = transform.GetOrAddComponent<DragObject>();
			
		}

		highlightEffect = transform.GetOrAddComponent<HighlightEffect>();
		highlightEffect.highlighted = true;

		renderer = GetComponent<Renderer>();
		originalMaterial = renderer.material;
		renderer.material = UnityConstant.Instance.FlatMaterial;
	}
	
	public void SetFinished()
	{
		if (!isFixed)
		{
			dragObject.EnableDrag(false);
		}
		highlightEffect.highlighted = false;

		SetOriginalMaterial();
	}

	private void SetOriginalMaterial()
	{
		renderer.material = originalMaterial;
	}
}
