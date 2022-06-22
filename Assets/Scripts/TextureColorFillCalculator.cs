// void* src: https://gist.github.com/andrew-raphael-lukasik/73720c7a9aae0ff9faefd4f7b2a21660
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor;
using UnityEditor.UIElements;

public class TextureColorFillCalculator : EditorWindow
{
	Texture2D _texture;
	
	public void OnEnable ()
	{
		var PREVIEW = new Image();
		var TOLERANCE = new Slider();
		var FIELD = new ObjectField();
		var COLOR = new ColorField();
		rootVisualElement.Add( FIELD );
		rootVisualElement.Add( PREVIEW );
		rootVisualElement.Add( COLOR );
		rootVisualElement.Add( TOLERANCE );

		// PREVIEW
		PREVIEW.image = _texture;
		PREVIEW.scaleMode = ScaleMode.ScaleAndCrop;
		PREVIEW.style.flexGrow = 1f;

		// COLOR
		COLOR.label = "Reference color:";
		COLOR.value = Color.white;
		COLOR.RegisterValueChangedCallback( (e) => RefreshInfo() );
		void RefreshInfo ()
		{
			if( _texture!=null )
			{
				var colors = _texture.GetPixels();
				float fill = CalculateFill( colors , COLOR.value , TOLERANCE.value );
				float similarity = CalculateSimilarity( colors , COLOR.value );
				COLOR.label = $"Texture is {(similarity*100f):0.0}% similar and {(fill*100f):0.00}% filled with this color ";
			}
		}
		RefreshInfo();

		// TOLERANCE
		TOLERANCE.label = "Fill tolerance [%]:";
		TOLERANCE.value = 0.1f;
		TOLERANCE.lowValue = 0f;
		TOLERANCE.highValue = 1f;
		TOLERANCE.RegisterValueChangedCallback( (e) => RefreshInfo() );

		// FIELD
		FIELD.objectType = typeof(Texture2D);
		FIELD.value = _texture;
		FIELD.RegisterValueChangedCallback(
			(e) =>
			{
				var newTexture = e.newValue as Texture2D;
				if( newTexture!=null )
				{
					if( newTexture.isReadable )
					{
						_texture = newTexture;
						PREVIEW.image = newTexture;
						RefreshInfo();
					}
					else
					{
						UnityEditor.EditorUtility.DisplayDialog(
							"Texture is not readable" ,
							$"Texture '{newTexture.name}' is not readable. Choose different texture or enable \"Read/Write Enabled\" for needs of this demonstration." ,
							"OK"
						);
						_texture = null;
						PREVIEW.image = null;
						return;
					}
				}
				else
				{
					_texture = null;
					PREVIEW.image = null;
					COLOR.label = "no texture";
				}
			}
		);
	}

	static float CalculateSimilarity ( Color[] colors , Color reference )
	{
		Vector3 target = new Vector3{ x=reference.r , y=reference.g , z=reference.b };
		float accu = 0;
		const float sqrt_3 = 1.73205080757f;
		for( int i=0 ; i<colors.Length ; i++ )
		{
			Vector3 next = new Vector3{ x=colors[i].r , y=colors[i].g , z=colors[i].b };
			accu += Vector3.Magnitude( target - next ) / sqrt_3;
		}
		return 1f - ( (float)accu / (float)colors.Length );
	}
	static float CalculateFill ( Color[] colors , Color reference , float tolerance )
	{
		Vector3 target = new Vector3{ x=reference.r , y=reference.g , z=reference.b };
		int numHits = 0;
		const float sqrt_3 = 1.73205080757f;
		for( int i=0 ; i<colors.Length ; i++ )
		{
			Vector3 next = new Vector3{ x=colors[i].r , y=colors[i].g , z=colors[i].b };
			float mag = Vector3.Magnitude( target - next ) / sqrt_3;
			numHits += mag<=tolerance ? 1 : 0;
		}
		return (float)numHits / (float)colors.Length;;
	}

	[MenuItem("Tools/Texture Color Fill Calculator")]
	static void ShowWindow () => GetWindow<TextureColorFillCalculator>().titleContent = new GUIContent("Texture Color Fill Calculator");
	
}
