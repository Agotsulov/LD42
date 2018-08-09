package com.ld42.game.ecs.systems;

import com.badlogic.gdx.Gdx;
import com.ld42.game.ecs.components.TextComponent;
import com.ld42.game.ecs.core.Engine;
import com.ld42.game.ecs.core.Entity;
import com.ld42.game.ecs.core.System;

public class TextDebugLogSystem extends System{

    public TextDebugLogSystem(Engine engine, String name) {
        super(engine, name);
    }

    @Override
    public void update() {
        for(int i = 0;i < engine.getScene().size();i++){
            Entity e = engine.getScene().get(i);
            for(int j = 0;j < e.size();j++){
                if(e.get(j) instanceof TextComponent)
                    Gdx.app.log("TextDebugLogSystem","" + ((TextComponent) e.get(j)).getText());
            }
        }
    }
}
