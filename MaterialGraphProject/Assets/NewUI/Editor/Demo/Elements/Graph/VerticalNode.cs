using UnityEngine;
using UnityEngine.RMGUI;

namespace RMGUI.GraphView.Demo
{
	[GUISkinStyle("box")]
	class VerticalNode : GraphElement
	{
		readonly VisualContainer m_ContainerTop;
		readonly VisualContainer m_ContainerBottom;

		public VerticalNode()
		{
			m_ContainerTop = new VisualContainer
			{
				name = "top",
				pickingMode = PickingMode.Ignore
			};

			m_ContainerBottom = new VisualContainer
			{
				name = "bottom",
				pickingMode = PickingMode.Ignore
			};

			AddChild(m_ContainerTop);
			AddChild(m_ContainerBottom);
		}

		public override void DoRepaint(PaintContext painter)
		{
			base.DoRepaint(painter);
			if (GetData<VerticalNodeData>() != null && GetData<VerticalNodeData>().selected)
			{
				painter.DrawRectangleOutline(transform, position, Color.yellow);
			}
		}

		public override void OnDataChanged()
		{
			base.OnDataChanged();
			m_ContainerTop.ClearChildren();
			m_ContainerBottom.ClearChildren();
			var nodeData = GetData<VerticalNodeData>();

			if (nodeData != null)
			{
				foreach (var anchorData in nodeData.anchors)
				{
					m_ContainerTop.AddChild(new NodeAnchor(anchorData));
				}
				m_ContainerBottom.AddChild(new NodeAnchor(nodeData.outputAnchor));
			}
		}
	}
}
