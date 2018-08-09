package com.ld42.game.ecs.components;

import com.ld42.game.ecs.core.Component;
import com.ld42.game.ecs.core.Engine;

public class TextComponent extends Component{

    private String text;

    public TextComponent(Engine engine, String name, String text) {
        super(engine, name);
        setText(text);
    }

    public String getText() {
        return text;
    }

    public void setText(String text) {
        this.text = text;
    }
}
