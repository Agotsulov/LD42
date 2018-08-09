package com.ld42.game.ecs.core;

public abstract class System extends GameObject{

    public System(Engine engine, String name) {
        super(engine, name);
    }

    public abstract void update();

}
